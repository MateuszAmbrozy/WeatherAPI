﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deserialize_classes
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class City
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }

        [ForeignKey("Root")]
        public int RootId { get; set; }
        public virtual Root Root { get; set; }
    }

    public class Clouds
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        public int all { get; set; }
    }

    public class Coord
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class List
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public int visibility { get; set; }
        public string pop { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }

        [ForeignKey("Root")]
        public int RootId { get; set; }
        public virtual Root Root { get; set; }
    }

    public class Main
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class Root
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        [Required]
        public List<List> list { get; set; }
        [Required]
        public City city { get; set; }

        public override string ToString()
        {
            return $"City: {city?.name}, Temp: {list?.FirstOrDefault()?.main?.temp}";
        }
    }

    public class Sys
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        public string pod { get; set; }
    }

    public class Weather
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int my_id { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }



}
