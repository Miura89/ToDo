using Microsoft.AspNetCore.Mvc;
using ToDo.Entidades;

namespace ToDo.Repositorio
{
    public interface ITodoRepositorio
    {
        Task AdicionarTarefa(ToDoEntity entidade);
        Task<IEnumerable<ToDoDto>> TodasTarefas();
    }
}
