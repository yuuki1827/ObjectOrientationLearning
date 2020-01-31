using System;
using System.Collections.Generic;

// 【継承のメリット】
//     ・処理を移譲できる
//     ・カスタマイズできる
//     ・管理コストが安定する

namespace ObjectOrientationLearning
{
    /// <summary>
    /// コカコーラの自販機クラス
    /// </summary>
    public class CocaCola : VendingMachine
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CocaCola() : base("コカコーラ")
        {
            AddItem("コーラ", 120);
            AddItem("アクエリアス", 150);
            AddItem("モンスター", 200);
        }
    }
}
