using System;
using System.Collections.Generic;

namespace ObjectOrientationLearning
{
    // 自販機ベースクラス
    public class VendingMachine
    {
        string _name;
        List<string> _itemNames;
        List<int> _itemPrices;

        /// <summary>
        /// 商品リストのプロパティ
        /// </summary>
        public virtual List<string> ItemNames
        {
            get { return this._itemNames; }
        }

        /// <summary>
        /// 商品価格リストのプロパティ
        /// </summary>
        public virtual List<int> ItemPrices
        {
            get { return this._itemPrices; }
        }

        public VendingMachine() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">自販機の名前</param>
        protected VendingMachine(String name)
        {
            this._name = name;
            _itemNames = new List<string>();
            _itemPrices = new List<int>();
        }

        /// <summary>
        /// 商品を追加する
        /// </summary>
        public void AddItem(string name, int price)
        {
            _itemNames.Add(name);
            _itemPrices.Add(price);
        }

        /// <summary>
        /// 商品の場所（添字）を取得する
        /// </summary>
        public virtual int GetItem(String name)
        {
            return _itemNames.IndexOf(name);
        }

        /// <summary>
        /// 商品を買う
        /// </summary>
        public virtual KeyValuePair<string, int> Pyment(int index, ref int money)
        {
            var product = new KeyValuePair<string, int>(_itemNames[index], _itemPrices[index]);

            if (money > product.Value)
            {
                money -= product.Value;
                return product;
            }

            // nullを返却
            return new KeyValuePair<string, int>();
        }
    }
}
