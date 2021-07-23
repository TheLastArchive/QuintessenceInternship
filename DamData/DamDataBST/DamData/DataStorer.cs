using System;
using System.Collections.Generic;
using System.Linq;

namespace DamData
{
    class DataStorer
    {
        private string[] data;
        private string[] maxDamCapacaties;
        private string[] damNames;
        private string[] headers;
        private string[] storageUnits;
        private string[] dates;
        public List<Dam> damObjects;
        public BinaryTree damObjectsTree = new BinaryTree();

        public DataStorer(string data) => this.data = data.TrimEnd('\n').Split('\n');
                                                                            //Create a new string array to split the string with.
        private void ExtractMaxDamCapacities() => maxDamCapacaties = data[1].Trim(',').Replace(",,,,", ",,,").Split(new string[] { ",,," }, StringSplitOptions.None);

        private void ExtractDamNames() => damNames = data[2].Trim(',').Split(new string[] { ",,,," }, StringSplitOptions.None);

        private void ExtractHeaders() => headers = data[3].Split(',').Take(5).ToArray();

        private void ExtractStorageUnits() => storageUnits = data[4].Trim(',').Split(',').Take(5).ToArray();

        private void ExtractDates()
        {
            List<string> tempList = new List<string>();
            for (int i = 5; i < data.Length; i++)
            {
                tempList.Add(data[i].Split(',')[0]);
                data[i] = data[i].Remove(0, 10); //Remove date from the string
            }
            dates = tempList.ToArray();
        }

        private void ExtractCapacities()
        {
            foreach (Dam dam in damObjects)
            {
                List<List<string>> damCapacityListHolder = new List<List<string>>();
                for (int columnIndex = 5; columnIndex < data.Length; columnIndex++)
                {
                    List<string> damCapacityList = new List<string>();
                    string[] rowOfData = data[columnIndex].Split(',');
                    damCapacityList = AddElementsToDamCapacityList(damCapacityList, rowOfData);
                    damCapacityListHolder.Add(damCapacityList);
                    data[columnIndex] = String.Join(",", rowOfData.Skip(4)); //Remove the elements iterated over
                }
                dam.damCapacities = damCapacityListHolder;
            }
        }

        private List<string> AddElementsToDamCapacityList(List<string> damCapacityList, string[] rowOfData)
        {
            for (int i = 0; i < 4; i++)
                damCapacityList.Add(rowOfData[i]);

            return damCapacityList;
        }

        private void CreateDamObjectsAndAddToList()
        {
            damObjects = new List<Dam>();
            for (int i = 0; i < damNames.Length; i++)
                damObjects.Add(new Dam(damNames[i], maxDamCapacaties[i], headers, storageUnits));
        }

        private void CreateDamDictionaries()
        {
            foreach (Dam dam in damObjects)
                dam.CreateDamDataDictionary(dates);
        }

        private void CreateDamBinarySearchTree()
        {
            foreach (Dam dam in damObjects)
                damObjectsTree.Add(dam);
        }

        public void SplitAndStoreData()
        {
            ExtractMaxDamCapacities();
            ExtractDamNames();
            ExtractHeaders();
            ExtractStorageUnits();
            CreateDamObjectsAndAddToList();
            ExtractDates();
            ExtractCapacities();
            CreateDamDictionaries();
            CreateDamBinarySearchTree();
        }
    }
}
