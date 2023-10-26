using RegressionGames.BehaviorTree;
using RegressionGames.RGBotLocalRuntime;

namespace RgAbilitybotCs
{
    public class IsThereAPlayerNearby : ConditionNode
    {
        public IsThereAPlayerNearby() : base("Is there a player nearby?")
        {
        }

        /**
         * Generated from prompt:
         * 
         */
        public override NodeStatus Execute(RG rgObject)
        {
        	return NodeStatus.FAILURE;
        }
    }
}