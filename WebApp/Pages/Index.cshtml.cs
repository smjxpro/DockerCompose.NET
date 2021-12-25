using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ITodoRepository _todoRepository;

    public IndexModel(ILogger<IndexModel> logger, ITodoRepository todoRepository)
    {
        _logger = logger;
        _todoRepository = todoRepository;
    }

    public IList<Todo> Todos { get; set; } = new List<Todo>();
    public async Task OnGetAsync()
    {
        Todos = (await _todoRepository.GetAllTodo()).ToList();
    }

    public void OnChane(Guid id)
    {
        Console.WriteLine(id);
    }
}