using Microsoft.AspNetCore.Mvc;
using ToDo.Entidades;
using ToDo.Repositorio;

namespace ToDo.Controllers
{
    [Route("/v1")]
    public class ControllerTeste : ControllerBase
    {
        private readonly ITodoRepositorio _repositorio;

        public ControllerTeste(ITodoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("/")]
        public string HelloWorld()
        {
            return "hello world";
        }
        [HttpGet("/teste")]
        public string Teste()
        {
            return "teste";
        }
        [HttpPost("/criar-tarefa")]
        public async Task<ActionResult> Criar([FromBody] ToDoEntity entidade)
        {
            await _repositorio.AdicionarTarefa(entidade);
            return Ok(entidade);
        }

        [HttpGet("pegar-todos")]
        public async Task<ActionResult<IEnumerable<ToDoEntity>>> BuscarTodos()
        {
            var tarefas = await _repositorio.TodasTarefas();
            return Ok(tarefas);
        }
    }
}
