﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eShopApp.Models;
using System.Linq;

namespace eShopApp.Services
{
    public class CartService : ICartSerivce
    {
        //private static readonly CartService instance = new CartService();
        //static CartService() { } // Make sure it's truly lazy
        //private CartService() { } // Prevent instantiation outside

        //public static CartService Instance { get { return instance; } }

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
                Quantity = 4,
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
                Quantity = 4,
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

        public void AddCartItem(CartItem cartItem)
        {
            CartItems.Add(cartItem);
        }

        public ObservableCollection<CartItem> GetCartItems(int uid)
        {
            var gettingResult = CartItems.Where(ci => ci.UserId == uid)
                .Select(ci =>
                {
                    if (ci.Quantity <= ci.Product.Quantity)
                        ci.IsAvailable = true;
                    else
                        ci.IsAvailable = false;

                    return ci;
                }).ToList();

            var observableList = new ObservableCollection<CartItem>(gettingResult);
            return observableList;
        }

        public int GetNumberOfCartItems(int uid)
        {
            return CartItems.Where(ci => ci.UserId == uid).Sum(ci=>ci.Quantity);
        }

        public void RemoveItemFromCart(CartItem cartItem)
        {
            CartItems.Remove(cartItem);
        }

        public void SubmitOrder(int uid)
        {
            throw new NotImplementedException();
        }
    }
}
