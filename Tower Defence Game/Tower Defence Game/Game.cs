namespace Tower_Defence_Game
{
    public partial class Game : Form
    {
        PopUpBar bar;
        public Game()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //create top side on form load
            topDecoration topSide = new topDecoration();
            gameLayout.Controls.Add(topSide, 0, 0);
            gameLayout.SetColumnSpan(topSide, 3);

            //create leftsidebar
            SideLayout leftSideBar = new SideLayout(3, 1);
            gameLayout.Controls.Add(leftSideBar, 0, 1);

            //create map
            Map mainMap = new Map();
            gameLayout.Controls.Add(mainMap, 1, 1);

            //create popUpBar
            bar = PopUpBar.initPopUpBar();
        }
    }
}
