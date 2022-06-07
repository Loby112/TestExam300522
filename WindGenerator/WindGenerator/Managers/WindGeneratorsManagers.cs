using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using WindGenerator.Models;

namespace WindGenerator.Managers {
    public class WindGeneratorsManagers{
        private static int nextId = 1;

        private static List<WindDataGenerator> _generators = new List<WindDataGenerator>(){
            new WindDataGenerator(){Direction = "N", Speed = 8, Id = nextId++},
            new WindDataGenerator(){Direction = "E", Speed = 9, Id = nextId++},
            new WindDataGenerator(){Direction = "NE", Speed = 3, Id = nextId++},
            new WindDataGenerator(){Direction = "S", Speed = 5, Id = nextId++},
            new WindDataGenerator(){Direction = "NW", Speed = 4, Id = nextId++}
        };

        public IEnumerable<WindDataGenerator> GetAll(int? speed){
            List<WindDataGenerator> result = new List<WindDataGenerator>(_generators);
            if (speed != null){
                result = _generators.FindAll(w => w.Speed > speed);
            }
            
            return result;
        }

        public WindDataGenerator AddWindData(WindDataGenerator newWindData){
            newWindData.Id = nextId++;
            _generators.Add(newWindData);
            return newWindData;
        }
    }
}
