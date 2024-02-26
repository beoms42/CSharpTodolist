using Newtonsoft.Json;

namespace CSharpTodolist.Models
{
    public class TodoList
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }
        public int? Id { get; set; }
        public TodoList() { }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this) ?? "thisOBJisNull";
        }
    }
}
