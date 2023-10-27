using RegressionGames.BehaviorTree;
using RegressionGames.RGBotLocalRuntime;
using RegressionGames.StateActionTypes;
using UnityEngine;

namespace RgAbilitybotCs
{
    public class PerformSkill : ActionNode
    {
        public PerformSkill() : base("Perform Skill")
        {
        }

        /**
         * Generated from prompt:
         * 
         */
        public override NodeStatus Execute(RG rgObject)
        {
        	var selectedSkill = GetData<int>("selectedSkill");
        	var target = GetData<RGStateEntity>("targetEntity");
        
        	var targetPosition = target.position ?? Vector3.zero;
        	var action = new RGActionRequest("PerformSkill", new()
        	{
        		["skillId"] = selectedSkill,
        		["targetId"] = target["id"],
        		["xPosition"] = targetPosition.x,
        		["yPosition"] = targetPosition.y,
        		["zPosition"] = targetPosition.z,
        	});
        	rgObject.PerformAction(action);
        	return NodeStatus.Success;
        }
    }
}