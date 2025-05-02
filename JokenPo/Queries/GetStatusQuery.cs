using JokenPo.Models;
using JokenPo.Models.RequestResponses;
using MediatR;

namespace JokenPo.Queries
{
    public class GetStatusQuery : IRequest<GetStatusQueryResponse> {}
}
