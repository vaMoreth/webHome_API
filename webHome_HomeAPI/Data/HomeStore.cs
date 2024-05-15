using webHome_HomeAPI.Models.Dto;

namespace webHome_HomeAPI.Data
{
    public static class HomeStore
    {
        public static List<HomeDTO> homeList = 
                new List<HomeDTO>() {
                new HomeDTO { Id = 1, Name = "Home 1", Occupancy = 4, Sqft = 100 },
                new HomeDTO { Id = 2, Name = "Home 2", Occupancy = 3, Sqft = 300}
            };
    }
}
