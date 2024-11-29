namespace ToDo.Entidades
{
    public class ToDoEntity
    {
        public ToDoEntity(int id, string nome, string tarefa, bool feito)
        {
            Id = id;
            Nome = nome;
            Tarefa = tarefa;
            Feito = feito;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tarefa { get; set; }
        public bool Feito { get; set; }
    }
}
