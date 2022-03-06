using System;
using System.Collections.Generic;
using Bargain.Models;

namespace Bargain.Repositories.Contexts
{
    public static class MockDatabase
    {
        public static IEnumerable<Region> Regions => new List<Region>
        {
            new Region { Id = 1, Name = "Australian Capital Territory", Code = "ACT" },
            new Region { Id = 2, Name = "New South Wales",              Code = "NSW" },
            new Region { Id = 3, Name = "Northern Territory",           Code = "NT"  },
            new Region { Id = 4, Name = "Queensland",                   Code = "QLD" },
            new Region { Id = 5, Name = "South Australia",              Code = "SA"  },
            new Region { Id = 6, Name = "Tasmania",                     Code = "TAS" },
            new Region { Id = 7, Name = "Victoria",                     Code = "VIC" },
            new Region { Id = 8, Name = "Western Australia",            Code = "WA"  },
        };

        public static IEnumerable<Location> Locations => new List<Location>
        {
            new Location { Id = 1, RegionId = 2, Timezone = TimezoneType.AEST, Name = "Sydney"       },
            new Location { Id = 2, RegionId = 2, Timezone = TimezoneType.AEST, Name = "Wollongong"   },
            
            new Location { Id = 3, RegionId = 5, Timezone = TimezoneType.ACST, Name = "Adelaide"     },
            new Location { Id = 4, RegionId = 5, Timezone = TimezoneType.ACST, Name = "Mount Barker" },
            
            new Location { Id = 5, RegionId = 7, Timezone = TimezoneType.AEST, Name = "Melbourne"    },
            new Location { Id = 6, RegionId = 7, Timezone = TimezoneType.AEST, Name = "Geelong"      },
            new Location { Id = 7, RegionId = 7, Timezone = TimezoneType.AEST, Name = "Ballarat"     },

            new Location { Id = 8, RegionId = 8, Timezone = TimezoneType.AWST, Name = "Perth"        },
        };

        public static IEnumerable<Category> Categories => new List<Category>
        {
            new Category { Id = 1, Name = "Cafe"       },
            new Category { Id = 2, Name = "Restaurant" },
            new Category { Id = 3, Name = "Bar"        },
            new Category { Id = 4, Name = "Beauty"     },
            new Category { Id = 5, Name = "Hair Salon" },
            new Category { Id = 6, Name = "Bakery",    Inactive = true },
            new Category { Id = 7, Name = "Cars",      Inactive = true },
        };

        public static IEnumerable<User> Users => new List<User>
        {
            new User { 
                Id = 1,
                RecordId = new Guid("ca73ddcc-9a0a-4f0b-bb1c-88d48f8f81ca"),
                Name = "UserOne Email",        
                Email = "user1@email.com",        
                Role = RoleType.Customer,       
                Type = AuthType.Email                    
            },
            new User { 
                Id = 2,
                RecordId = new Guid("824778aa-b41a-4162-b951-5a7a9e3aed5d"),
                Name = "MerchantOne Facebook", 
                Email = "merchant1@facebook.com", 
                Role = RoleType.Merchant,   
                Type = AuthType.Facebook,                
                IsTradeAdmin = true 
            },
            new User { 
                Id = 3,
                RecordId = new Guid("11966b4c-d952-4a79-a8cf-8ccad9368388"),
                Name = "MerchantTwo Google",   
                Email = "merchant2@gmail.com",    
                Role = RoleType.Merchant,   
                Type = AuthType.Google                
            },
            new User { 
                Id = 4,
                RecordId = new Guid("d2aa67b7-f342-4474-a2d1-188dc4390b84"),
                Name = "AdminOne Facebook",    
                Email = "admin1@facebook.com",    
                Role = RoleType.SiteAdmin,      
                Type = AuthType.Facebook                
            },
            new User { 
                Id = 5,
                RecordId = new Guid("0c50fe37-3aaf-4bbc-8e77-7c4dc4ee6399"),
                Name = "MerchantThree Email",  
                Email = "merchant3@email.com",   
                Role = RoleType.Merchant,   
                Type = AuthType.Email,                
                IsTradeAdmin = true 
            },
            new User { 
                Id = 6,
                RecordId = new Guid("e46b3643-dca2-461a-a4ee-2d0d9dc42bf9"),
                Name = "AdminTwo Email",       
                Email = "admin2@email.com",       
                Role = RoleType.SiteAdmin,      
                Type = AuthType.Email                
            },
            new User { 
                Id = 7,
                RecordId = new Guid("a0c36ffb-6cdd-4cf2-b63e-3c2bad14aee2"),
                Name = "UserTwo Facebook",     
                Email = "user2@facebook.com",     
                Role = RoleType.Customer,       
                Type = AuthType.Facebook                
            },
            new User { 
                Id = 8,
                RecordId = new Guid("fd9bce38-fb78-413f-8696-c054ab684aa0"),
                Name = "MerchantFour Google",  
                Email = "merchant4@gmail.com",    
                Role = RoleType.Merchant,   
                Type = AuthType.Google,                
                IsTradeAdmin = true 
            },
            new User { 
                Id = 9,
                RecordId = new Guid("f969aa58-5ccc-4780-bfc1-5370e8025b71"),
                Name = "SuperOne Email",       
                Email = "super@email.com",        
                Role = RoleType.DataAdmin, 
                Type = AuthType.Email                
            },
            new User { 
                Id = 10,
                RecordId = new Guid("bc54caa9-dc17-4bf8-8eff-95ccb0a769bd"),
                Name = "UserThree Google",     
                Email = "user3@gmail.com",        
                Role = RoleType.Customer,       
                Type = AuthType.Google                
            },
        };

        public static IEnumerable<Trade> Trades => new List<Trade>
        {
            new Trade {
                Id = 1,
                Name = "Trade One Branch One",
                Address = "100 Little Collins St",
                LocationId = 5,
                PlaceId = "ae5ff2c1bf13481888f5c8eed54ac6be",
                PhoneNumber = "(03) 4123 6666",
                Website = "https://www.trade1.com.au",                
                Status = ActionType.Approved
            },
            new Trade {
                Id = 2,
                Name = "Trade One Branch Two",
                Address = "1/45 Flinders Ln, Bourke St",
                LocationId = 5,
                PlaceId = "f82a6da65a6645eebbac345dc631e602",                
                Status = ActionType.Approved                
            },
            new Trade {
                Id = 3,
                Name = "Trade One Branch Three",
                Address = "50 Hindley St",
                LocationId = 3,
                PlaceId = "401beb5788324a0e8e514a8fc44e78e5",
                PhoneNumber = "(08) 5678 5555",
                Website = "https://www.trade3.com.au",                
                Status = ActionType.Approved,
                OpeningHours = new List<string>
                {
                    "Monday: 8:00 am – 5:00 pm",
                    "Tuesday: 8:00 am – 5:00 pm",
                    "Wednesday: 8:00 am – 5:00 pm",
                    "Thursday: 8:00 am – 5:00 pm",
                    "Friday: 8:00 am – 8:00 pm",
                    "Saturday: 8:00 am – 8:00 pm",
                    "Sunday: 8:00 am – 4:00 pm"
                }
            },
            new Trade {
                Id = 4,
                Name = "Trade Two Branch One",
                Address = "594 Park Rd",
                LocationId = 3,
                PlaceId = "2c5324faa7ce442e8dac36279f59e4e9",
                PhoneNumber = "(08) 9879 0563",
                Website = "https://trade2.com.au/locationone",
                Status = ActionType.Approved,
                OpeningHours = new List<string>
                {
                    "Monday: Closed",
                    "Tuesday: 11:00 am – 8:00 pm",
                    "Wednesday: 11:00 am – 8:00 pm",
                    "Thursday: 11:00 am – 8:30 pm",
                    "Friday: 11:00 am – 8:30 pm",
                    "Saturday: 11:00 am – 8:30 pm",
                    "Sunday: 12:00 – 8:30 pm"
                }
            },
            new Trade {
                Id = 5,
                Name = "Trade Two Branch Two",
                Address = "1/947 Centre Rd",
                LocationId = 1,
                PlaceId = "8053d34624e14f9cb38e847796c86a74",
                PhoneNumber = "(02) 9570 9000",
                Website = "https://trade2.com.au/locationtwo",                
                Status = ActionType.Approved
            },
            new Trade {
                Id = 6,
                Name = "Trade Three One Branch",
                Address = "38 Wyndham St",
                LocationId = 8,
                PlaceId = "6d06ef9192414d3fbc1da7f8948435fd",
                PhoneNumber = "(08) 5849 1400",
                Website = "https://www.facebook.com/tradethree",
                Status = ActionType.Approved,
                OpeningHours = new List<string>
                {
                    "Monday: 7:00 am – 4:30 pm",
                    "Tuesday: 7:00 am – 4:30 pm",
                    "Wednesday: 7:00 am – 4:30 pm",
                    "Thursday: 7:00 am – 4:30 pm",
                    "Friday: 7:00 am – 4:30 pm",
                    "Saturday: 7:00 am – 4:30 pm",
                    "Sunday: 7:00 am – 4:30 pm"
                }
            },
        };

        public static IEnumerable<TradeFile> TradeFiles => new List<TradeFile>
        {
            new TradeFile { Id = 1,  TradeId = 1, Name = "Trade File 01", FileType = FileType.Bmp,  File = new byte[100] },
            new TradeFile { Id = 2,  TradeId = 1, Name = "Trade File 02", FileType = FileType.Bmp,  File = new byte[100] },

            new TradeFile { Id = 3,  TradeId = 3, Name = "Trade File 03", FileType = FileType.Jpeg, File = new byte[100] },
            new TradeFile { Id = 4,  TradeId = 3, Name = "Trade File 04", FileType = FileType.Jpeg, File = new byte[100] },
            new TradeFile { Id = 5,  TradeId = 3, Name = "Trade File 05", FileType = FileType.Jpeg, File = new byte[100] },
            new TradeFile { Id = 6,  TradeId = 3, Name = "Trade File 06", FileType = FileType.Jpeg, File = new byte[100] },
            new TradeFile { Id = 7,  TradeId = 3, Name = "Trade File 07", FileType = FileType.Jpeg, File = new byte[100] },
            new TradeFile { Id = 8,  TradeId = 3, Name = "Trade File 08", FileType = FileType.Png,  File = new byte[100] },
            new TradeFile { Id = 9,  TradeId = 3, Name = "Trade File 09", FileType = FileType.Png,  File = new byte[100] },
            new TradeFile { Id = 10, TradeId = 3, Name = "Trade File 10", FileType = FileType.Png,  File = new byte[100] },
            new TradeFile { Id = 11, TradeId = 3, Name = "Trade File 11", FileType = FileType.Png,  File = new byte[100] },
            new TradeFile { Id = 12, TradeId = 3, Name = "Trade File 12", FileType = FileType.Png,  File = new byte[100] },

            new TradeFile { Id = 13, TradeId = 4, Name = "Trade File 13", FileType = FileType.Jpeg, File = new byte[100] },
            new TradeFile { Id = 14, TradeId = 4, Name = "Trade File 14", FileType = FileType.Jpeg, File = new byte[100] },           

            new TradeFile { Id = 15, TradeId = 6, Name = "Trade File 15", FileType = FileType.Png,  File = new byte[100] },            
        };

        public static IEnumerable<TradeUser> TradeUsers => new List<TradeUser>
        {
            new TradeUser { UserId = 2, TradeId = 1  },
            new TradeUser { UserId = 2, TradeId = 2  },
            new TradeUser { UserId = 2, TradeId = 3  },            

            new TradeUser { UserId = 3, TradeId = 2,  IsEditAllowed = false },
            new TradeUser { UserId = 3, TradeId = 3,  IsEditAllowed = true  },

            new TradeUser { UserId = 5, TradeId = 4  },
            new TradeUser { UserId = 5, TradeId = 5  },            

            new TradeUser { UserId = 8, TradeId = 6  },            
        };

        public static IEnumerable<Deal> Deals => new List<Deal>
        {
            new Deal { 
                Id = 1, 
                Title = "Two Delectable French Meals",
                CategoryId = 1, 
                NoOfDeals = 10, 
                StartDate = new DateTime(2021, 06, 01).ToUniversalTime(), 
                ExpiryDate = new DateTime(2021, 06, 25).ToUniversalTime(), 
                Conditions = "Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions", 
                Status = ActionType.Approved
            }, 
            new Deal {
                Id = 2,
                Title = "Food Voucher for Two People - Options for Four or Six people",
                CategoryId = 1,
                NoOfDeals = 1,
                StartDate = new DateTime(2021, 06, 01).ToUniversalTime(),                
                Conditions = "Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions",
                Status = ActionType.Approved
            },
            new Deal {
                Id = 3,
                Title = "Food & Beverage Irish Pub Voucher",
                CategoryId = 3,
                NoOfDeals = 5,
                StartDate = new DateTime(2021, 06, 01).ToUniversalTime(),
                ExpiryDate = new DateTime(2021, 06, 25).ToUniversalTime(),
                Conditions = "Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions",
                Status = ActionType.Approved
            },
            new Deal {
                Id = 4,
                Title = "Cafe Weekday Breakfast, Brunch or Lunch for One Person",
                CategoryId = 1,
                NoOfDeals = 0,
                StartDate = new DateTime(2021, 06, 01).ToUniversalTime(),
                ExpiryDate = new DateTime(2021, 06, 25).ToUniversalTime(),
                Conditions = "Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions Test Conditions",
                Status = ActionType.Approved
            },
        };

        public static IEnumerable<DealType> DealTypes => new List<DealType>
        {
            new DealType {
                Id = 1,
                DealId = 1,
                Title = "$60 for Two People",
                Price = 90,
                DiscountType = DiscountType.Price,
                DiscountValue = 30
            },
            new DealType {
                Id = 2,
                DealId = 1,
                Title = "$120 for Four Feople",
                Price = 165,
                DiscountType = DiscountType.Price,
                DiscountValue = 45
            },
            new DealType {
                Id = 3,
                DealId = 1,
                Title = "$180 for Six People",
                Price = 240,
                DiscountType = DiscountType.Price,
                DiscountValue = 60
            },
            new DealType {
                Id = 4,
                DealId = 2,
                Title = "Half price for Four People",
                Price = 150,
                DiscountType = DiscountType.Percentage,
                DiscountValue = 50
            },
            new DealType {
                Id = 5,
                DealId = 3,
                Title = "Two People",
                Price = 60,
                DiscountType = DiscountType.Price,
                DiscountValue = 20
            },
            new DealType {
                Id = 6,
                DealId = 3,
                Title = "Six People",
                Price = 120,
                DiscountType = DiscountType.Percentage,
                DiscountValue = 30
            },
            new DealType {
                Id = 7,
                DealId = 4,
                Title = "Half price for a Family of Four",
                Price = 300,
                DiscountType = DiscountType.Price,
                DiscountValue = 150
            },
        };

        public static IEnumerable<DealFile> DealFiles => new List<DealFile>
        {
            new DealFile { DealId = 1, TradeFileId = 1   },
            new DealFile { DealId = 1, TradeFileId = 2   },
            new DealFile { DealId = 1, TradeFileId = 3,  IsPrimary = true },
            new DealFile { DealId = 1, TradeFileId = 4   },
            new DealFile { DealId = 1, TradeFileId = 5   },

            new DealFile { DealId = 2, TradeFileId = 3   },
            new DealFile { DealId = 2, TradeFileId = 7   },
            new DealFile { DealId = 2, TradeFileId = 8,  IsPrimary = true },
            new DealFile { DealId = 2, TradeFileId = 10  },
            new DealFile { DealId = 2, TradeFileId = 12  },

            new DealFile { DealId = 3, TradeFileId = 13, IsPrimary = true },
            new DealFile { DealId = 3, TradeFileId = 14  },

            new DealFile { DealId = 4, TradeFileId = 15, IsPrimary = true },                        
        };

        public static IEnumerable<TradeDeal> TradeDeals => new List<TradeDeal>
        {
            new TradeDeal { DealId = 1, TradeId = 1  },
            new TradeDeal { DealId = 1, TradeId = 2  },
            new TradeDeal { DealId = 1, TradeId = 3  },

            new TradeDeal { DealId = 2, TradeId = 1  },
            new TradeDeal { DealId = 2, TradeId = 2  },            

            new TradeDeal { DealId = 3, TradeId = 4  },
            new TradeDeal { DealId = 3, TradeId = 5  },

            new TradeDeal { DealId = 4, TradeId = 6  },            
        };
    }
}
