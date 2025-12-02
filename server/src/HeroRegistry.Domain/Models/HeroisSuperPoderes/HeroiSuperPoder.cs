using HeroRegistry.Domain.Models.Herois;
using HeroRegistry.Domain.Models.SuperPoderes;

namespace HeroRegistry.Domain.Models.HeroisSuperPoderes
{
    public class HeroiSuperPoder(int heroiId, int superPoderId)
    {
        public Heroi Heroi { get; set; } = new Heroi("", "", null, 0, 0);
        public int HeroiId { get; set; } = heroiId;
        public Poder SuperPoder { get; set; } = new Poder();
        public int SuperPoderId { get; set; } = superPoderId;
    }
}