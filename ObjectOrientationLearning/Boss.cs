using System;
using System.Collections.Generic;

// 【プロパティのメリット】
//     ・読み取り/書き込みの制御ができる
//     ・読み取り/書き込みでカスタマイズできる

namespace ObjectOrientationLearning
{
    /// <summary>
    /// BOSSの自販機システム
    /// </summary>
    public class Boss : Acure
    {
        // 飲料の状態を管理する変数
        // 「あったかい」「つめたい」「常温」
        public enum DrinkStatus
        {
            hot, cool, normal
        }

        List<DrinkStatus> drinkStatuses;

        /// <summary>
        /// 特定の飲料状態を選ぶ
        /// </summary>
        DrinkStatus nowStatus;
        public DrinkStatus NowStatus
        {
            set { this.nowStatus = value; }
        }

        /// <summary>
        /// 指定した飲料状態の飲み物の名前一覧を取得する
        /// </summary>
        public override List<string> ItemNames
        {
            get
            {
                var itemNamesIndex = FindIndex(this.nowStatus);
                var itemNameList = new List<string>();

                for (int i = 0; i < itemNamesIndex.Count; i++)
                {
                    itemNameList.Add(base.ItemNames[itemNamesIndex[i]]);
                }
                return itemNameList;
            }
        }

        /// <summary>
        /// 指定した飲料状態の飲み物の価格一覧を取得する
        /// </summary>
        public override List<int> ItemPrices
        {
            get
            {
                var itemPricesIndex = FindIndex(this.nowStatus);
                var itemPricesList = new List<int>();

                for (int i = 0; i < itemPricesIndex.Count; i++)
                {
                    itemPricesList.Add(base.ItemPrices[itemPricesIndex[i]]);
                }
                return itemPricesList;
            }
        }

        /// <summary>
        /// 【機能条件】
        ///     ・CocaColaとAcureの機能を持っている
        ///     ・(new) あったかい/つめたい
        ///         -> 自販機を選ぶ時のように、
        ///            商品一覧を表示する前で「あったかい」「つめたい」どちらの飲み物を買うか選択させる
        /// </summary>
        public Boss() : base("Boss")
        {
            drinkStatuses = new List<DrinkStatus>();

            AddItem("コーヒー（あったかい）", 120, 1, DrinkStatus.hot);
            AddItem("コーヒー（つめたい）", 120, 1, DrinkStatus.cool);
            AddItem("お茶（常温）", 150, 1, DrinkStatus.normal);
        }

        /// <summary>
        /// 商品を追加する
        /// </summary>
        public void AddItem(string name, int price, int count, DrinkStatus status)
        {
            base.AddItem(name, price, count);
            drinkStatuses.Add(status);
        }

        /// <summary>
        /// 特定の飲料状態から商品の索引(index)を全て取得する
        /// </summary>
        public List<int> FindIndex(DrinkStatus status)
        {
            var result = new List<int>();

            for (int i = 0; i < drinkStatuses.Count; i++)
            {
                if (status == drinkStatuses[i])
                {
                    // 特定のValueが管理されているindexを取得
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
