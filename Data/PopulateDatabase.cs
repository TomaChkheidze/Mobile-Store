using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Mobile_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_Store.Data
{
    public class PopulateDatabase
    {
        private readonly MobileStoreContext _context;

        public PopulateDatabase(MobileStoreContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.AddRange(
                    new Brand
                    {
                        Id = 1,
                        Name = "Apple"
                    },
                    new Brand
                    {
                        Id = 2,
                        Name = "Samsung"
                    },
                    new Brand
                    {
                        Id = 3,
                        Name = "Xiaomi"
                    },
                    new Brand
                    {
                        Id = 4,
                        Name = "OnePlus"
                    },
                    new Brand
                    {
                        Id = 5,
                        Name = "Google"
                    },
                    new Brand
                    {
                        Id = 6,
                        Name = "Nokia"
                    });
                await _context.SaveChangesAsync();
            }
            if (!_context.Phones.Any())
            {
                _context.Phones.AddRange(
                    new Phone
                    {
                        Id = 1,
                        Title = "Apple iPhone SE 2020 Single Sim 64GB black",
                        BrandId = 1,
                        RAM = 3,
                        Memory = 64,
                        ScreenSize = 4.7f,
                        ScreenResolution = "750 x 1334",
                        Size = "138.4 x 67.3 x 7.3",
                        OS = "iOS",
                        Weight = 148,
                        CPU = "Hexa-core (2x2.65 GHz Lightning + 4x1.8 GHz Thunder)",
                        Price = 1699f,
                        Media = new string[]
                        {
                            "https://img.zoommer.ge/zoommer-images/thumbs/0115776_apple-iphone-se-2020-single-sim-64gb-black_550.png",
                            "https://img.zoommer.ge/zoommer-images/thumbs/0115778_apple-iphone-se-2020-single-sim-64gb-black_550.png"
                        }
                    },
                    new Phone
                    {
                        Id = 2,
                        Title = "Apple iPhone 11 Pro Single Sim 256GB gold",
                        BrandId = 1,
                        RAM = 4,
                        Memory = 256,
                        ScreenSize = 5.8f,
                        ScreenResolution = "1125 x 2436",
                        Size = "144 x 71.4 x 8.1",
                        OS = "iOS",
                        Weight = 148,
                        CPU = "Hexa-core (2x2.65 GHz Lightning + 4x1.8 GHz Thunder)",
                        Price = 4499f,
                        Media = new string[]
                        {
                            "https://img.zoommer.ge/zoommer-images/thumbs/0108304_apple-iphone-11-pro-single-sim-256gb-gold_550.png",
                            "https://img.zoommer.ge/zoommer-images/thumbs/0108305_apple-iphone-11-pro-single-sim-256gb-gold_550.png"
                        }
                    },
                    new Phone
                    {
                        Id = 9,
                        Title = "Google Pixel 4 Single sim 6GB RAM 64GB LTE GA01187-US Just Black",
                        BrandId = 5,
                        RAM = 6,
                        Memory = 64,
                        ScreenSize = 5.7f,
                        ScreenResolution = "1080 x 2280",
                        Size = "147.1 x 68.8 x 8.2",
                        OS = "Android 10",
                        Weight = 148,
                        CPU = "Octa-core (1x2.84 GHz Kryo 485 & 3x2.42 GHz Kryo 485 & 4x1.78 GHz Kryo 485)",
                        Price = 4499f,
                        Media = new string[]
                        {
                            "https://img.zoommer.ge/zoommer-images/thumbs/0107377_google-pixel-4-single-sim-6gb-ram-64gb-lte-ga01187-us-just-black_550.png",
                            "https://img.zoommer.ge/zoommer-images/thumbs/0107378_google-pixel-4-single-sim-6gb-ram-64gb-lte-ga01187-us-just-black_550.png"
                        }
                    },
                    new Phone
                    {
                        Id = 3,
                        Title = "Samsung Galaxy Note 20 8GB RAM 256GB LTE N980FD Mystic Bronze",
                        BrandId = 2,
                        RAM = 8,
                        Memory = 256,
                        ScreenSize = 6.7f,
                        ScreenResolution = "1080 x 2400",
                        Size = "161.6 x 75.2 x 8.3",
                        OS = "Android 10",
                        Weight = 192,
                        CPU = "Octa-core (2x2.73 GHz Mongoose M5 & 2x2.50 GHz Cortex-A76 & 4x2.0 GHz Cortex-A55)",
                        Price = 2699f,
                        Media = new string[]
                        {
                            "https://img.zoommer.ge/zoommer-images/thumbs/0122531_samsung-galaxy-note-20-8gb-ram-256gb-lte-n980fd-mystic-bronze_550.png",
                            "https://img.zoommer.ge/zoommer-images/thumbs/0122533_samsung-galaxy-note-20-8gb-ram-256gb-lte-n980fd-mystic-bronze_550.png"
                        }
                    },
                    new Phone
                    {
                        Id = 4,
                        Title = "Samsung Galaxy M31s M317FD Dual Sim 6GB RAM 128GB LTE Mirage Black",
                        BrandId = 2,
                        RAM = 6,
                        Memory = 128,
                        ScreenSize = 6.5f,
                        ScreenResolution = "1080 x 2400",
                        Size = "159.3 x 74.4 x 9.3",
                        OS = "Android 10",
                        Weight = 203,
                        CPU = "Octa-core (4x2.3 GHz Cortex-A73 & 4x1.7 GHz Cortex-A53)",
                        Price = 979f,
                        Media = new string[]
                        {
                            "https://img.zoommer.ge/zoommer-images/thumbs/0125406_samsung-galaxy-m31s-m317fd-dual-sim-6gb-ram-128gb-lte-mirage-black_550.png"
                        }
                    },
                    new Phone
                    {
                        Id = 5,
                        Title = "Xiaomi Poco X3 NFC Dual Sim 6GB RAM 128GB LTE Global Version Grey",
                        BrandId = 3,
                        RAM = 6,
                        Memory = 128,
                        ScreenSize = 6.67f,
                        ScreenResolution = "1080 x 2400",
                        Size = "165.3 x 76.8 x 9.4",
                        OS = "Android 10",
                        Weight = 215,
                        CPU = "Octa-core (2x2.3 GHz Kryo 470 Gold & 6x1.8 GHz Kryo 470 Silver)",
                        Price = 1049f,
                        Media = new string[]
                        {
                            "https://img.zoommer.ge/zoommer-images/thumbs/0125406_samsung-galaxy-m31s-m317fd-dual-sim-6gb-ram-128gb-lte-mirage-black_550.png"
                        }
                    },
                    new Phone
                    {
                        Id = 6,
                        Title = "OnePlus 8 Dual Sim 12GB RAM 256GB LTE Global Version glow",
                        BrandId = 4,
                        RAM = 12,
                        Memory = 256,
                        ScreenSize = 6.55f,
                        ScreenResolution = "1080 x 2400",
                        Size = "165.3 x 76.8 x 9.4",
                        OS = "Android 10",
                        Weight = 190,
                        CPU = "Octa-core (1x2.84 GHz Kryo 585 & 3x2.42 GHz Kryo 585 & 4x1.80 GHz Kryo 585)",
                        Price = 2699f,
                        Media = new string[]
                        {
                            "https://img.zoommer.ge/zoommer-images/thumbs/0119082_oneplus-8-dual-sim-12gb-ram-256gb-lte-global-version-glow_550.png",
                            "https://img.zoommer.ge/zoommer-images/thumbs/0119084_oneplus-8-dual-sim-12gb-ram-256gb-lte-global-version-glow_550.png"
                        }
                    },
                    new Phone
                    {
                        Id = 7,
                        Title = "Nokia 5.3 Dual Sim 4GB RAM 64GB LTE Cyan",
                        BrandId = 6,
                        RAM = 4,
                        Memory = 64,
                        ScreenSize = 6.55f,
                        ScreenResolution = "720 x 1600",
                        Size = "164.3 x 76.6 x 8.5",
                        OS = "Android 10",
                        Weight = 185,
                        CPU = "Octa - core(4x2.0 GHz Kryo 260 Gold & 4x1.8 GHz Kryo 260 Silver)",
                        Price = 549f,
                        Media = new string[]
                        {
                            "https://img.zoommer.ge/zoommer-images/thumbs/0121836_nokia-53-dual-sim-4gb-ram-64gb-lte-cyan_550.png",
                            "https://img.zoommer.ge/zoommer-images/thumbs/0121836_nokia-53-dual-sim-4gb-ram-64gb-lte-cyan_550.png",
                            "https://img.zoommer.ge/zoommer-images/thumbs/0121837_nokia-53-dual-sim-4gb-ram-64gb-lte-cyan_550.png"
                        }
                    },
                    new Phone
                    {
                        Id = 8,
                        Title = "Nokia 2720 Dual Sim black",
                        BrandId = 6,
                        RAM = 1,
                        Memory = 4,
                        ScreenSize = 2.4f,
                        ScreenResolution = "240 x 320",
                        Size = "164.3 x 76.6 x 8.5",
                        OS = "Kai OS",
                        Weight = 185,
                        CPU = "Dual-core (2x1.1 GHz Cortex-A7)",
                        Price = 299f,
                        Media = new string[]
                        {
                            "https://img.zoommer.ge/zoommer-images/thumbs/0113182_nokia-2720-dual-sim-black_550.png"
                        }
                    });

                await _context.SaveChangesAsync();
            }
        }
    }
}
