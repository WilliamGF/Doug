﻿using System;
using Doug.Models;
using Doug.Models.Combat;
using Doug.Repositories;

namespace Doug.Skills
{
    public abstract class Skill
    {
        public int EnergyCost { get; set; }
        public int Cooldown { get; set; }

        protected readonly IStatsRepository StatsRepository;

        protected Skill(IStatsRepository statsRepository)
        {
            StatsRepository = statsRepository;
        }

        public virtual DougResponse Activate(User user, ICombatable target, string channel)
        {
            return new DougResponse(DougMessages.SkillCannotBeActivated);
        }

        protected bool CanActivateSkill(User user, out DougResponse response)
        {
            if (user.IsSkillOnCooldown())
            {
                response = new DougResponse(string.Format(DougMessages.CommandOnCooldown, user.CalculateStealCooldownRemaining()));
                return false;
            }

            if (!user.HasEnoughEnergyForCost(EnergyCost))
            {
                response = new DougResponse(DougMessages.NotEnoughEnergy);
                return false;
            }

            user.Energy -= EnergyCost;
            StatsRepository.UpdateEnergy(user.Id, user.Energy);
            StatsRepository.SetSkillCooldown(user.Id, TimeSpan.FromSeconds(Cooldown));
            response = new DougResponse();
            return true;
        }
    }
}
