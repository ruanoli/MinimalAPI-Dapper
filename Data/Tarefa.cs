using System.ComponentModel.DataAnnotations.Schema;


namespace TarefaApiDapper.Data;

    //Records é um tipo de dados leve, imutável e de somente leitura.
    //Records só pode ser inicializado através de um construtor.
    [Table("Tarefas")]
    public record Tarefa(int Id, string Atividades, string Status)
    {
        
    }
