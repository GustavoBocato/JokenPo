namespace JokenPo.Models.RequestResponses
{
    public class GetStatusQueryResponse
    {
        public List<Player> Players {  get; set; }
        public string ResultMessage { get; set; }
    }
}
