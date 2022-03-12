using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMediator _mediator;

    public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public IList<Todo> Todos { get; set; } = new List<Todo>();

    public async Task OnGetAsync()
    {
        Todos = (await _mediator.Send(new GetAllTodoQuery())).ToList();
    }

    public void OnChange(Guid id)
    {
        Console.WriteLine(id);
    }
}