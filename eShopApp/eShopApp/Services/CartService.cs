using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eShopApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace eShopApp.Services
{
    public class CartService : BaseService, ICartSerivce
    {
        #region commented
        /*
        IList<CartItem> CartItems { get; set; } = new List<CartItem>()
        {
            new CartItem
            {
                UserId = 1,
                ProductId = 1,
                Product = new Product
                {
                    Id = 1,
                    Name = "LG Smart TV 21\"",
                    Description = "This LG LED TV offers unmatched entertainment. With the resolution of 1920 x 1080 pixels, this 43inch TV renders clear and detailed images so that you don’t miss out even on minutest of details. The top-notch dynamic color processing technology brings images to life. Thanks to the Virtual surround sound, this LG TV recreates the exceptional sound, thereby making your favorite sporting events all the more fun. With HDMI and USB port, you can connect entertainment devices to your TV. The eye-catching frames add a touch of modernity to this LG FHD TV. With built-in HD receiver, you are set to enjoy HD content immediately without any additional external support. The slim construction of this LG TV makes it a must-have for your living room.",
                    Price=  300,
                    Quantity= 6,
                    ImagePosterUrl = "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                    CreatedDate = new DateTime(2019,7,19,21,2,50,4),
                    Images = new List<string>
                    {
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                        "https://thegoodguys.sirv.com/products/50052624/50052624_562897.PNG",
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                        "https://thegoodguys.sirv.com/products/50052624/50052624_562897.PNG",
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                    }
                },
                Quantity = 0,
                CreatedDate = DateTime.Now
            },
            new CartItem
            {
                UserId = 1,
                ProductId = 2,
                Product = new Product
                {
                    Id = 2,
                    Name = "LG Smart TV 43\"",
                    Description = "This LG LED TV offers unmatched entertainment. With the resolution of 1920 x 1080 pixels, this 43inch TV renders clear and detailed images so that you don’t miss out even on minutest of details. The top-notch dynamic color processing technology brings images to life. Thanks to the Virtual surround sound, this LG TV recreates the exceptional sound, thereby making your favorite sporting events all the more fun. With HDMI and USB port, you can connect entertainment devices to your TV. The eye-catching frames add a touch of modernity to this LG FHD TV. With built-in HD receiver, you are set to enjoy HD content immediately without any additional external support. The slim construction of this LG TV makes it a must-have for your living room.",
                    Price=  1000,
                    Quantity= 2,
                    ImagePosterUrl = "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                    CreatedDate = new DateTime(2019,7,19,21,2,50,4),
                    Images = new List<string>
                    {
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                        "https://thegoodguys.sirv.com/products/50052624/50052624_562897.PNG",
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                        "https://thegoodguys.sirv.com/products/50052624/50052624_562897.PNG",
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                    }
                },
                Quantity = 0,
                CreatedDate = DateTime.Now
            },
            new CartItem
            {
                UserId = 2,
                ProductId = 1,
                Product = new Product
                {
                    Id = 1,
                    Name = "LG Smart TV 21\"",
                    Description = "This LG LED TV offers unmatched entertainment. With the resolution of 1920 x 1080 pixels, this 43inch TV renders clear and detailed images so that you don’t miss out even on minutest of details. The top-notch dynamic color processing technology brings images to life. Thanks to the Virtual surround sound, this LG TV recreates the exceptional sound, thereby making your favorite sporting events all the more fun. With HDMI and USB port, you can connect entertainment devices to your TV. The eye-catching frames add a touch of modernity to this LG FHD TV. With built-in HD receiver, you are set to enjoy HD content immediately without any additional external support. The slim construction of this LG TV makes it a must-have for your living room.",
                    Price=  300,
                    Quantity= 6,
                    ImagePosterUrl = "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                    CreatedDate = new DateTime(2019,7,19,21,2,50,4),
                    Images = new List<string>
                    {
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                        "https://thegoodguys.sirv.com/products/50052624/50052624_562897.PNG",
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                        "https://thegoodguys.sirv.com/products/50052624/50052624_562897.PNG",
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                    }
                },
                Quantity = 4,
                CreatedDate = DateTime.Now
            },
            new CartItem
            {
                UserId = 2,
                ProductId = 2,
                Product = new Product
                {
                    Id = 2,
                    Name = "LG Smart TV 43\"",
                    Description = "This LG LED TV offers unmatched entertainment. With the resolution of 1920 x 1080 pixels, this 43inch TV renders clear and detailed images so that you don’t miss out even on minutest of details. The top-notch dynamic color processing technology brings images to life. Thanks to the Virtual surround sound, this LG TV recreates the exceptional sound, thereby making your favorite sporting events all the more fun. With HDMI and USB port, you can connect entertainment devices to your TV. The eye-catching frames add a touch of modernity to this LG FHD TV. With built-in HD receiver, you are set to enjoy HD content immediately without any additional external support. The slim construction of this LG TV makes it a must-have for your living room.",
                    Price=  1000,
                    Quantity= 2,
                    ImagePosterUrl = "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                    CreatedDate = new DateTime(2019,7,19,21,2,50,4),
                    Images = new List<string>
                    {
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                        "https://thegoodguys.sirv.com/products/50052624/50052624_562897.PNG",
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                        "https://thegoodguys.sirv.com/products/50052624/50052624_562897.PNG",
                        "https://www.lg.com/pa_en/images/tvs/MD05606915/gallery/medium01.jpg",
                    }
                },
                Quantity = 4,
                CreatedDate = DateTime.Now
            }
        };
        */
        #endregion

        const string url = "CartItems";

        public async Task<bool> AddCartItem(CartItem cartItem)
        {
            var response = await Client.PostAsync(url,
                new StringContent(
                    JsonConvert.SerializeObject(cartItem),
                    Encoding.UTF8,"application/json"));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<ObservableCollection<CartItem>> GetCartItems(int uid)
        {
            var response = await Client.GetAsync($"{url}/{uid}");
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                var cartItems = JsonConvert.DeserializeObject<IList<CartItem>>(message);
                cartItems.Where(ci => ci.UserId == uid)
                .Select(ci =>
                {
                    if (ci.Quantity <= ci.Product.Quantity)
                        ci.IsAvailable = true;
                    else
                        ci.IsAvailable = false;

                    return ci;
                }).ToList();

                var observableList = new ObservableCollection<CartItem>(cartItems);
                return observableList;
            }

            return new ObservableCollection<CartItem>();
        }

        public async Task<int> GetNumberOfCartItems(int uid)
        {
            var response = await Client.GetAsync($"{url}/count/{uid}");
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                var count = JsonConvert.DeserializeObject<int>(message);

                return count;
            }

            return 0;
        }

        public async Task<bool> RemoveItemFromCart(CartItem cartItem)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{BaseUrl}{url}"),
                Content = new StringContent(JsonConvert.SerializeObject(cartItem), Encoding.UTF8, "application/json")
            };

            var response = await Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
