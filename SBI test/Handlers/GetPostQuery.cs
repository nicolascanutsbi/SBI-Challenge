using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Json;

public class GetPostQuery : IRequest<Salida>
{
    public int PostId { get; }

    public GetPostQuery(int postId)
    {
        PostId = postId;
    }
}

public class GetPostQueryHandler : IRequestHandler<GetPostQuery, Salida>
{
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;

    public GetPostQueryHandler(IMapper mapper, HttpClient httpClient)
    {
        _mapper = mapper;
        _httpClient = httpClient;
    }

    public async Task<Salida> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
        response.EnsureSuccessStatusCode();

        var serverPosts = await response.Content.ReadFromJsonAsync<ServerPost[]>();

        var serverPost = serverPosts.SingleOrDefault(p => p.id == request.PostId);

        if (serverPost == null)
        {
            return null;
        }

        var salida = _mapper.Map<Salida>(serverPost);

        return salida;
    }
}
