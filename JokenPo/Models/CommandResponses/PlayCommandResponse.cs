namespace JokenPo.Models.CommandResponses
{
    public class PlayCommandResponse
    {
        public bool MoveMadeSuccessfully { get; set; }
        public bool GameEnded { get; set; }
        public Player? Winner { get; set; }
    }
}
