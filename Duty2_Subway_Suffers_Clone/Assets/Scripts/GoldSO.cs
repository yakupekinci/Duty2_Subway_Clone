using UnityEngine;

[CreateAssetMenu(fileName = "NewGoldData", menuName = "Gold Data", order = 1)]
public class GoldSO : ScriptableObject
{
    public int goldAmount = 0; // Altın miktarı
    // İhtiyacınıza göre diğer altın özelliklerini ekleyebilirsiniz
}
