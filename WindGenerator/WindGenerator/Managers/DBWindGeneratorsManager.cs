using System.Collections.Generic;
using System.Linq;
using WindGenerator.Models;

namespace WindGenerator.Managers {
    public class DBWindGeneratorsManager {
        private WindDataDBContext _context = new WindDataDBContext();

        public DBWindGeneratorsManager(){

        }

        public IEnumerable<WindDataGenerator> GetAll(int? speed){
            IEnumerable<WindDataGenerator> result = _context.WindDatas;
            if (speed != null){
                return result.Where(d => d.Speed > speed);
            }
            
            return result;
        }

        public WindDataGenerator AddWindData(WindDataGenerator newData){
            newData.Id = 0;
            _context.WindDatas.Add(newData);
            _context.SaveChanges();
            return newData;
        }
    }
}
