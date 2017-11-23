
namespace Models {
    class Utilidades {

        public static string simboloAtribuicao = "::=";
        public static char epsolon = '~';

        public static System.Text.RegularExpressions.Regex expressaoOperadores = new System.Text.RegularExpressions.Regex("[:+\\-*\\/=&¬%><]{1}");

        public static System.Text.RegularExpressions.Regex expressaoEspacosDuplos = new System.Text.RegularExpressions.Regex("[ ]{2,}");

    }
}
