
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.HBox hbox24;

	private global::Gtk.VBox vbox6;

	private global::Gtk.Frame frame6;

	private global::Gtk.Alignment GtkAlignment7;

	private global::Gtk.DrawingArea drawingarea;

	private global::Gtk.Label GtkLabel7;

	private global::Gtk.VBox vbox27;

	private global::Gtk.Frame frame27;

	private global::Gtk.Alignment GtkAlignment4;

	private global::Gtk.VBox vbox29;

	private global::Gtk.HBox hbox25;

	private global::Gtk.Arrow arrow10;

	private global::Gtk.Label label58;

	private global::Gtk.HBox hbox27;

	private global::Gtk.Arrow arrow12;

	private global::Gtk.Label label60;

	private global::Gtk.HBox hbox29;

	private global::Gtk.Arrow arrow14;

	private global::Gtk.Label label62;

	private global::Gtk.Label GtkLabel4;

	private global::Gtk.Frame frame29;

	private global::Gtk.Alignment GtkAlignment1;

	private global::Gtk.VBox vbox9;

	private global::Gtk.Button button6;

	private global::Gtk.Label label1;

	private global::Gtk.Label GtkLabel2;

	private global::Gtk.Frame frame31;

	private global::Gtk.Alignment GtkAlignment3;

	private global::Gtk.HBox hbox2;

	private global::Gtk.Button button7;

	private global::Gtk.Button button8;

	private global::Gtk.Label GtkLabel5;

	private global::Gtk.Frame frame39;

	private global::Gtk.Alignment GtkAlignment6;

	private global::Gtk.VBox vbox40;

	private global::Gtk.Label label90;

	private global::Gtk.Label label92;

	private global::Gtk.Label label94;

	private global::Gtk.Label GtkLabel8;

	private global::Gtk.Frame frame37;

	private global::Gtk.Alignment GtkAlignment5;

	private global::Gtk.VBox vbox35;

	private global::Gtk.VBox vbox36;

	private global::Gtk.Label label82;

	private global::Gtk.Label label84;

	private global::Gtk.VBox vbox38;

	private global::Gtk.Label label86;

	private global::Gtk.Label label88;

	private global::Gtk.Label GtkLabel6;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("Program Evolution Review Technique");
		this.Icon = global::Stetic.IconLoader.LoadIcon(this, "gtk-find-and-replace", global::Gtk.IconSize.Menu);
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		this.AllowShrink = true;
		this.DefaultWidth = 1000;
		this.DefaultHeight = 600;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.hbox24 = new global::Gtk.HBox();
		this.hbox24.Name = "hbox24";
		this.hbox24.Spacing = 6;
		// Container child hbox24.Gtk.Box+BoxChild
		this.vbox6 = new global::Gtk.VBox();
		this.vbox6.Name = "vbox6";
		this.vbox6.Spacing = 6;
		// Container child vbox6.Gtk.Box+BoxChild
		this.frame6 = new global::Gtk.Frame();
		this.frame6.Name = "frame6";
		this.frame6.BorderWidth = ((uint)(12));
		// Container child frame6.Gtk.Container+ContainerChild
		this.GtkAlignment7 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment7.Name = "GtkAlignment7";
		// Container child GtkAlignment7.Gtk.Container+ContainerChild
		this.drawingarea = new global::Gtk.DrawingArea();
		this.drawingarea.Name = "drawingarea";
		this.GtkAlignment7.Add(this.drawingarea);
		this.frame6.Add(this.GtkAlignment7);
		this.GtkLabel7 = new global::Gtk.Label();
		this.GtkLabel7.Name = "GtkLabel7";
		this.GtkLabel7.Xpad = 5;
		this.GtkLabel7.Ypad = 4;
		this.GtkLabel7.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Le r??seau PERT</b>");
		this.GtkLabel7.UseMarkup = true;
		this.frame6.LabelWidget = this.GtkLabel7;
		this.vbox6.Add(this.frame6);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.frame6]));
		w3.Position = 0;
		this.hbox24.Add(this.vbox6);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox24[this.vbox6]));
		w4.Position = 0;
		// Container child hbox24.Gtk.Box+BoxChild
		this.vbox27 = new global::Gtk.VBox();
		this.vbox27.Name = "vbox27";
		this.vbox27.Homogeneous = true;
		this.vbox27.Spacing = 6;
		this.vbox27.BorderWidth = ((uint)(12));
		// Container child vbox27.Gtk.Box+BoxChild
		this.frame27 = new global::Gtk.Frame();
		this.frame27.Name = "frame27";
		// Container child frame27.Gtk.Container+ContainerChild
		this.GtkAlignment4 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment4.Name = "GtkAlignment4";
		// Container child GtkAlignment4.Gtk.Container+ContainerChild
		this.vbox29 = new global::Gtk.VBox();
		this.vbox29.Name = "vbox29";
		this.vbox29.Spacing = 6;
		// Container child vbox29.Gtk.Box+BoxChild
		this.hbox25 = new global::Gtk.HBox();
		this.hbox25.Name = "hbox25";
		this.hbox25.Spacing = 6;
		// Container child hbox25.Gtk.Box+BoxChild
		this.arrow10 = new global::Gtk.Arrow(((global::Gtk.ArrowType)(3)), ((global::Gtk.ShadowType)(2)));
		this.arrow10.Name = "arrow10";
		this.hbox25.Add(this.arrow10);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox25[this.arrow10]));
		w5.Position = 0;
		w5.Expand = false;
		w5.Fill = false;
		// Container child hbox25.Gtk.Box+BoxChild
		this.label58 = new global::Gtk.Label();
		this.label58.Name = "label58";
		this.label58.LabelProp = global::Mono.Unix.Catalog.GetString("Toutes les t??ches du projet.");
		this.hbox25.Add(this.label58);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox25[this.label58]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		this.vbox29.Add(this.hbox25);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox29[this.hbox25]));
		w7.Position = 0;
		w7.Expand = false;
		w7.Fill = false;
		// Container child vbox29.Gtk.Box+BoxChild
		this.hbox27 = new global::Gtk.HBox();
		this.hbox27.Name = "hbox27";
		this.hbox27.Spacing = 6;
		// Container child hbox27.Gtk.Box+BoxChild
		this.arrow12 = new global::Gtk.Arrow(((global::Gtk.ArrowType)(3)), ((global::Gtk.ShadowType)(2)));
		this.arrow12.Name = "arrow12";
		this.hbox27.Add(this.arrow12);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox27[this.arrow12]));
		w8.Position = 0;
		w8.Expand = false;
		w8.Fill = false;
		// Container child hbox27.Gtk.Box+BoxChild
		this.label60 = new global::Gtk.Label();
		this.label60.Name = "label60";
		this.label60.LabelProp = global::Mono.Unix.Catalog.GetString("La dur??e de chaque t??che.");
		this.hbox27.Add(this.label60);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox27[this.label60]));
		w9.Position = 1;
		w9.Expand = false;
		w9.Fill = false;
		this.vbox29.Add(this.hbox27);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox29[this.hbox27]));
		w10.Position = 1;
		w10.Expand = false;
		w10.Fill = false;
		// Container child vbox29.Gtk.Box+BoxChild
		this.hbox29 = new global::Gtk.HBox();
		this.hbox29.Name = "hbox29";
		this.hbox29.Spacing = 6;
		// Container child hbox29.Gtk.Box+BoxChild
		this.arrow14 = new global::Gtk.Arrow(((global::Gtk.ArrowType)(3)), ((global::Gtk.ShadowType)(2)));
		this.arrow14.Name = "arrow14";
		this.hbox29.Add(this.arrow14);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox29[this.arrow14]));
		w11.Position = 0;
		w11.Expand = false;
		w11.Fill = false;
		// Container child hbox29.Gtk.Box+BoxChild
		this.label62 = new global::Gtk.Label();
		this.label62.Name = "label62";
		this.label62.LabelProp = global::Mono.Unix.Catalog.GetString("Les antecedants et les successeurs.");
		this.hbox29.Add(this.label62);
		global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox29[this.label62]));
		w12.Position = 1;
		w12.Expand = false;
		w12.Fill = false;
		this.vbox29.Add(this.hbox29);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox29[this.hbox29]));
		w13.Position = 2;
		w13.Expand = false;
		w13.Fill = false;
		this.GtkAlignment4.Add(this.vbox29);
		this.frame27.Add(this.GtkAlignment4);
		this.GtkLabel4 = new global::Gtk.Label();
		this.GtkLabel4.Name = "GtkLabel4";
		this.GtkLabel4.Ypad = 5;
		this.GtkLabel4.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Que doit contenir le fichier CSV ?</b>");
		this.GtkLabel4.UseMarkup = true;
		this.frame27.LabelWidget = this.GtkLabel4;
		this.vbox27.Add(this.frame27);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox27[this.frame27]));
		w16.Position = 0;
		// Container child vbox27.Gtk.Box+BoxChild
		this.frame29 = new global::Gtk.Frame();
		this.frame29.Name = "frame29";
		// Container child frame29.Gtk.Container+ContainerChild
		this.GtkAlignment1 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment1.Name = "GtkAlignment1";
		// Container child GtkAlignment1.Gtk.Container+ContainerChild
		this.vbox9 = new global::Gtk.VBox();
		this.vbox9.Name = "vbox9";
		this.vbox9.Spacing = 6;
		// Container child vbox9.Gtk.Box+BoxChild
		this.button6 = new global::Gtk.Button();
		this.button6.CanFocus = true;
		this.button6.Name = "button6";
		this.button6.UseUnderline = true;
		this.button6.BorderWidth = ((uint)(3));
		this.button6.Label = global::Mono.Unix.Catalog.GetString("Parcourir ...");
		global::Gtk.Image w17 = new global::Gtk.Image();
		w17.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-directory", global::Gtk.IconSize.Menu);
		this.button6.Image = w17;
		this.vbox9.Add(this.button6);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.button6]));
		w18.Position = 0;
		// Container child vbox9.Gtk.Box+BoxChild
		this.label1 = new global::Gtk.Label();
		this.label1.Name = "label1";
		this.label1.Wrap = true;
		this.label1.Justify = ((global::Gtk.Justification)(2));
		this.vbox9.Add(this.label1);
		global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.label1]));
		w19.Position = 1;
		this.GtkAlignment1.Add(this.vbox9);
		this.frame29.Add(this.GtkAlignment1);
		this.GtkLabel2 = new global::Gtk.Label();
		this.GtkLabel2.Name = "GtkLabel2";
		this.GtkLabel2.Ypad = 4;
		this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Charger un fichier CSV</b>");
		this.GtkLabel2.UseMarkup = true;
		this.frame29.LabelWidget = this.GtkLabel2;
		this.vbox27.Add(this.frame29);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox27[this.frame29]));
		w22.Position = 1;
		// Container child vbox27.Gtk.Box+BoxChild
		this.frame31 = new global::Gtk.Frame();
		this.frame31.Name = "frame31";
		// Container child frame31.Gtk.Container+ContainerChild
		this.GtkAlignment3 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment3.Name = "GtkAlignment3";
		// Container child GtkAlignment3.Gtk.Container+ContainerChild
		this.hbox2 = new global::Gtk.HBox();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button7 = new global::Gtk.Button();
		this.button7.CanFocus = true;
		this.button7.Name = "button7";
		this.button7.UseUnderline = true;
		this.button7.BorderWidth = ((uint)(5));
		this.button7.Label = global::Mono.Unix.Catalog.GetString("Dessiner le graphe");
		global::Gtk.Image w23 = new global::Gtk.Image();
		w23.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-edit", global::Gtk.IconSize.Menu);
		this.button7.Image = w23;
		this.hbox2.Add(this.button7);
		global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.button7]));
		w24.Position = 0;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button8 = new global::Gtk.Button();
		this.button8.CanFocus = true;
		this.button8.Name = "button8";
		this.button8.UseUnderline = true;
		this.button8.BorderWidth = ((uint)(5));
		this.button8.Label = global::Mono.Unix.Catalog.GetString("Effacer le graphe");
		global::Gtk.Image w25 = new global::Gtk.Image();
		w25.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-cancel", global::Gtk.IconSize.Menu);
		this.button8.Image = w25;
		this.hbox2.Add(this.button8);
		global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.button8]));
		w26.Position = 1;
		this.GtkAlignment3.Add(this.hbox2);
		this.frame31.Add(this.GtkAlignment3);
		this.GtkLabel5 = new global::Gtk.Label();
		this.GtkLabel5.Name = "GtkLabel5";
		this.GtkLabel5.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Control</b>");
		this.GtkLabel5.UseMarkup = true;
		this.frame31.LabelWidget = this.GtkLabel5;
		this.vbox27.Add(this.frame31);
		global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox27[this.frame31]));
		w29.Position = 2;
		// Container child vbox27.Gtk.Box+BoxChild
		this.frame39 = new global::Gtk.Frame();
		this.frame39.Name = "frame39";
		// Container child frame39.Gtk.Container+ContainerChild
		this.GtkAlignment6 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment6.Name = "GtkAlignment6";
		// Container child GtkAlignment6.Gtk.Container+ContainerChild
		this.vbox40 = new global::Gtk.VBox();
		this.vbox40.Name = "vbox40";
		this.vbox40.Spacing = 6;
		// Container child vbox40.Gtk.Box+BoxChild
		this.label90 = new global::Gtk.Label();
		this.label90.Name = "label90";
		this.label90.LabelProp = global::Mono.Unix.Catalog.GetString("Hamdi Skander - Groupe : 03");
		this.vbox40.Add(this.label90);
		global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox40[this.label90]));
		w30.Position = 0;
		w30.Expand = false;
		w30.Fill = false;
		// Container child vbox40.Gtk.Box+BoxChild
		this.label92 = new global::Gtk.Label();
		this.label92.Name = "label92";
		this.label92.LabelProp = global::Mono.Unix.Catalog.GetString("TP N??2 - Implementation de la m??thode PERT");
		this.label92.Wrap = true;
		this.vbox40.Add(this.label92);
		global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.vbox40[this.label92]));
		w31.Position = 1;
		w31.Expand = false;
		w31.Fill = false;
		// Container child vbox40.Gtk.Box+BoxChild
		this.label94 = new global::Gtk.Label();
		this.label94.Name = "label94";
		this.label94.LabelProp = global::Mono.Unix.Catalog.GetString("Module : Conduite de projet");
		this.vbox40.Add(this.label94);
		global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox40[this.label94]));
		w32.Position = 2;
		w32.Expand = false;
		w32.Fill = false;
		this.GtkAlignment6.Add(this.vbox40);
		this.frame39.Add(this.GtkAlignment6);
		this.GtkLabel8 = new global::Gtk.Label();
		this.GtkLabel8.Name = "GtkLabel8";
		this.GtkLabel8.Xpad = 7;
		this.GtkLabel8.Ypad = 9;
		this.GtkLabel8.LabelProp = global::Mono.Unix.Catalog.GetString("<b>R??alis?? par</b>");
		this.GtkLabel8.UseMarkup = true;
		this.frame39.LabelWidget = this.GtkLabel8;
		this.vbox27.Add(this.frame39);
		global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbox27[this.frame39]));
		w35.PackType = ((global::Gtk.PackType)(1));
		w35.Position = 3;
		// Container child vbox27.Gtk.Box+BoxChild
		this.frame37 = new global::Gtk.Frame();
		this.frame37.Name = "frame37";
		// Container child frame37.Gtk.Container+ContainerChild
		this.GtkAlignment5 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
		this.GtkAlignment5.Name = "GtkAlignment5";
		// Container child GtkAlignment5.Gtk.Container+ContainerChild
		this.vbox35 = new global::Gtk.VBox();
		this.vbox35.Name = "vbox35";
		this.vbox35.Spacing = 6;
		// Container child vbox35.Gtk.Box+BoxChild
		this.vbox36 = new global::Gtk.VBox();
		this.vbox36.Name = "vbox36";
		this.vbox36.Spacing = 6;
		// Container child vbox36.Gtk.Box+BoxChild
		this.label82 = new global::Gtk.Label();
		this.label82.Name = "label82";
		this.vbox36.Add(this.label82);
		global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox36[this.label82]));
		w36.Position = 0;
		w36.Expand = false;
		w36.Fill = false;
		// Container child vbox36.Gtk.Box+BoxChild
		this.label84 = new global::Gtk.Label();
		this.label84.Name = "label84";
		this.label84.UseMarkup = true;
		this.vbox36.Add(this.label84);
		global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox36[this.label84]));
		w37.Position = 1;
		w37.Expand = false;
		w37.Fill = false;
		this.vbox35.Add(this.vbox36);
		global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.vbox35[this.vbox36]));
		w38.Position = 0;
		w38.Expand = false;
		w38.Fill = false;
		// Container child vbox35.Gtk.Box+BoxChild
		this.vbox38 = new global::Gtk.VBox();
		this.vbox38.Name = "vbox38";
		this.vbox38.Spacing = 6;
		// Container child vbox38.Gtk.Box+BoxChild
		this.label86 = new global::Gtk.Label();
		this.label86.Name = "label86";
		this.vbox38.Add(this.label86);
		global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbox38[this.label86]));
		w39.Position = 0;
		w39.Expand = false;
		w39.Fill = false;
		// Container child vbox38.Gtk.Box+BoxChild
		this.label88 = new global::Gtk.Label();
		this.label88.Name = "label88";
		this.label88.UseMarkup = true;
		this.vbox38.Add(this.label88);
		global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.vbox38[this.label88]));
		w40.Position = 1;
		w40.Expand = false;
		w40.Fill = false;
		this.vbox35.Add(this.vbox38);
		global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.vbox35[this.vbox38]));
		w41.Position = 1;
		w41.Expand = false;
		w41.Fill = false;
		this.GtkAlignment5.Add(this.vbox35);
		this.frame37.Add(this.GtkAlignment5);
		this.GtkLabel6 = new global::Gtk.Label();
		this.GtkLabel6.Name = "GtkLabel6";
		this.GtkLabel6.Xpad = 6;
		this.GtkLabel6.Ypad = 4;
		this.GtkLabel6.LabelProp = global::Mono.Unix.Catalog.GetString("<b>R??sultats</b>");
		this.GtkLabel6.UseMarkup = true;
		this.frame37.LabelWidget = this.GtkLabel6;
		this.vbox27.Add(this.frame37);
		global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.vbox27[this.frame37]));
		w44.PackType = ((global::Gtk.PackType)(1));
		w44.Position = 4;
		this.hbox24.Add(this.vbox27);
		global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.hbox24[this.vbox27]));
		w45.Position = 1;
		w45.Expand = false;
		w45.Fill = false;
		this.Add(this.hbox24);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.button6.Clicked += new global::System.EventHandler(this.OpenControlFile);
		this.button7.Clicked += new global::System.EventHandler(this.start);
		this.button8.Clicked += new global::System.EventHandler(this.eraseGraphe);
	}
}
