using System;
using System.Collections.Generic;
using System.Linq;
using RegressionGames.BehaviorTree;
using RegressionGames.RGBotLocalRuntime;
using RegressionGames.StateActionTypes;
using UnityEngine;

namespace RgAbilitybotCs
{
    public class SelectSkill : ActionNode
    {
        public SelectSkill() : base("Select Skill")
        {
        }

        /**
         * Generated from prompt:
         * 
         */
        protected override NodeStatus Execute(RG rgObject)
        {
        	var target = GetData<RGStateEntity>("targetEntity");
        	var selectedSkill = target.GetValueOrDefault("team", 0) is 1 ? 1 : 0;
        	SetData("selectedSkill", selectedSkill);
        	return NodeStatus.Success;
        }
    }
}