using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.Entidades;

namespace ToDo.Repositorio
{
    public class TodoRepositorio : ITodoRepositorio
    {
        private readonly ApplicationContext _context;

        public TodoRepositorio(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AdicionarTarefa(ToDoEntity entidade)
        {
            var teste = new ToDoEntity(nome: entidade.Nome, tarefa: entidade.Tarefa, feito: entidade.Feito);
            teste.Id = GeradorId();
            await _context.AddAsync(teste);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<ToDoDto>> TodasTarefas()
        {
            return await _context.Todo.Select(x=> new ToDoDto
            {
                Id = x.Id,
                Feito = x.Feito,
                Nome = x.Nome,
                Tarefa = x.Tarefa,
            }).ToListAsync();
        }
        public static int GeradorId()
        {
            Random rnd = new Random();
            return rnd.Next(100, 999);
        }

        public async Task<bool> ConcluirTarefa(int id)
        {
            var tarefa = await _context.Todo.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(tarefa == null)
            {
                return false;
            }
            tarefa.Feito = true;
            _context.Update(tarefa);
            return true;
        }
    }
}
