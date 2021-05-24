using System;
using System.Collections.Generic;
using dio_series.Interfaces;

namespace dio_series {
    public class SeriesRepository : IRepository<Series> {
        private List<Series> allSeries = new List<Series>();
        public void UpdateEntity(int id, Series entity) {
            allSeries[id] = entity;
        }

        public void RemoveEntity(int id) {
            allSeries[id].RemoveSeries();
        }

        public void InsertEntity(Series entity) {
            allSeries.Add(entity);
        }

        public List<Series> ListEntities() {
            return allSeries;
        }

        public int NextId() {
            return allSeries.Count;
        }

        public Series GetById(int id) {
            return allSeries[id];
        }
    }
}