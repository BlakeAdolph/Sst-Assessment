namespace SstProgrammingandDesignProject.Models
{
    public class DiceRollResults
    {
        public List<int[]> Rolls { get; set; }

        public DiceRollResults()
        {
            Rolls = new List<int[]>();
        }
    }

}
