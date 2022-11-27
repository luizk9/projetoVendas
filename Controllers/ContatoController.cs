using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using projContato.Models;
using projContato.Repositorio;

namespace projContato.Controllers;

public class ContatoController : Controller
{
    private readonly IContatoRepositorio _contatoRepositorio;
    //ctor já cria o construtor
    // esse construtor servirar para injetar os repositorios
    public ContatoController(IContatoRepositorio contatoRepositorio)
    { // acessar o contatoRepositorio atraves da variavel de fora acima
        _contatoRepositorio = contatoRepositorio;    
    }

    public IActionResult Index()
    {
        List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
        return View(contatos);
    }

    public IActionResult Criar()
    {
        return View();
    }
    
    public IActionResult Editar(int id)
    {  
        ContatoModel contatoED = _contatoRepositorio.ListarPorId(id);
        return View(contatoED);
    }

    public IActionResult ApagarConfirmacao(int id)
    {
        ContatoModel contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    public IActionResult Apagar(int id)
    {
        try
        {
          bool apagado =  _contatoRepositorio.Apagar(id);
          if(apagado)
          {
            TempData["MensagemSucesso"] = "Contato deletado com sucesso";
           
          }else
          {
            TempData["MensagemErro"] = "danou-se errasse ....";

          }
           return RedirectToAction("Index");
              
            
        }
        catch (System.Exception erro)
        {
            
            TempData["MensagemErro"] = $"Opa, não conseguimos apagar..detalhe do erro:{erro.Message}";
            return RedirectToAction("Index"); 
        }
        
    }
    



// esses metodos acima sem identificador acima sao metodos gets
// agora abaixo vamos fazer os metodos post

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {    
        try
        {            
            if(ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(contato);
                TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            return View(contato);             
        }
        catch (System.Exception erro)
        {
             TempData["MensagemErro"] = $"Opa, não conseguimos cadastrar..detalhe do erro:{erro.Message}";
              return RedirectToAction("Index");        
        }      
        
    }

    [HttpPost]
    public IActionResult Alterar(ContatoModel contato)
    {
      try
      {
            if(ModelState.IsValid)
            {
                _contatoRepositorio.Atualizar(contato);
                 TempData["MensagemSucesso"] = "Contato Editado com sucesso";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Editar", contato);
      }
      catch (System.Exception erro)
      {
        
          TempData["MensagemErro"] = $"Opa, não conseguimos editar..detalhe do erro:{erro.Message}";
         return RedirectToAction ("Index");      
      }
    }



  
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
