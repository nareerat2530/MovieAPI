using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MovieProject.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();


                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                           ImageURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ImageURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the Thirst actor",
                            ImageURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the Fourth actor",
                            ImageURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the fifth actor",
                            ImageURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }




                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ImageURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ImageURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the Thirst actor",
                            ImageURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the Fourth actor",
                            ImageURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the Fifth actor",
                            ImageURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                //////Actors & Movies
                ////if (!context.ActorMovies.Any())
                ////{
                ////    context.ActorMovies.AddRange(new List<ActorMovie>()
                ////    {
                ////        new ActorMovie()
                ////        {
                ////            ActorId = 1,
                ////            MovieId = 1
                ////        },
                ////        new ActorMovie()
                ////        {
                ////            ActorId = 3,
                ////            MovieId = 1
                ////        },

                ////         new ActorMovie()
                ////        {
                ////            ActorId = 1,
                ////            MovieId = 2
                ////        },
                ////         new ActorMovie()
                ////        {
                ////            ActorId = 4,
                ////            MovieId = 2
                ////        },

                ////        new ActorMovie()
                ////        {
                ////            ActorId = 1,
                ////            MovieId = 3
                ////        },
                ////    });
                ////    context.SaveChanges();
                ////}

                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",

                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",

                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",

                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",

                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",

                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {

                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,

                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,

                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,

                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,

                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,

                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,

                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }


            }
        }
    }
}