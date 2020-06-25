[System.Serializable]
public struct Players
{
    [System.Serializable]
    public struct Player
    {
        public int idJogo;
        public string name;
        public int pontos;
        public System.DateTime quando;
    }

    public Player[] objetos;
}