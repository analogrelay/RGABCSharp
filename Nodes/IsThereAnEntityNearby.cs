using RegressionGames.BehaviorTree;
using RegressionGames.RGBotLocalRuntime;
using RegressionGames.StateActionTypes;
using UnityEngine;

namespace RgAbilitybotCs
{
    public class IsThereAnEntityNearby : ConditionNode
    {
        public IsThereAnEntityNearby() : base("Is there an entity nearby?")
        {
        }

        /**
         * Generated from prompt:
         * 
         */
        protected override NodeStatus Execute(RG rgObject)
        {
        	var random = new System.Random();
        	var entities = rgObject.FindEntities();
        	if (entities.Count > 0)
        	{
        		var selectedIndex = random.Next(entities.Count);
        		var target = entities[selectedIndex];
        		SetData("targetEntity", target);
        		return NodeStatus.Success;
        	}
        
        	return NodeStatus.Failure;
        }
    }
}