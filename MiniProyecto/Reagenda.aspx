<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reagenda.aspx.cs" Inherits="Re_Agenda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Clinica San Angel</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
		<link rel="stylesheet" href="assets/css/main.css" />
		<!--[if lte IE 8]><link rel="stylesheet" href="assets/css/ie8.css" /><![endif]-->
    
    
</head>
<body class="landing">
    <div id="page-wrapper">

			<!-- Header -->
				<header id="header" class="alt">
				   
					<nav id="nav">
						<ul>
							
							<li>
								<a href="#" class="icon fa-angle-down">Altas</a>                               
								<ul>
									<li><a href="AltaDoc.aspx">Altas Medicos</a></li>
									<li><a href="AltaPac.aspx">Altas Pacientes</a></li>									
								</ul>
							</li>
                            <li>
								<a href="#" class="icon fa-angle-down">Citas</a>                               
								<ul>
                                    <li><a href="Citas.aspx">Ver Citas</a></li>
									<li><a href="Agendas.aspx">Registro de Citas</a></li>
									<li><a href="Cancela.aspx">Cancelacion de Citas</a></li>
                                    <li><a href="Reagenda.aspx">Re Agendacion de Citas</a></li>
                                    									
								</ul>
							</li>
							<li></li>
						</ul>
					</nav>
				</header>

			<!-- Banner -->
				<section id="banner">
					<h2>Clinica San Angel</h2>
					<p>&nbsp;</p>
					<ul class="actions">
					</ul>
				</section>

			<!-- Main -->
				<section id="main" class="container">

					<section class="box special">
						<header class="major">
							<h2>Re Agendar</h2>
							<form id="form1" runat="server">
                              
                                <div>
                                 <h1>Seleccionar Cita a Reagendar</h1>
                                <br />
                                <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                                <br />

                                    <asp:Label ID="Label1" runat="server" Text="Seleccione el numero de cita a cambiar"></asp:Label> <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"   ></asp:DropDownList> 
                                </div>
                                <div id="reagendacion">
                                    <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
                                    <asp:Label ID="Label2" runat="server" Text="Medico" Visible="False"></asp:Label>
                                    <asp:DropDownList ID="DropDownList1" runat="server" Visible="False"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Seleccione un Medico" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="Paciente" Visible="False"></asp:Label>
                                    <asp:DropDownList ID="DropDownList3" runat="server" Visible="False"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Seleccione un Paciente" ControlToValidate="DropDownList3"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label ID="Label4" runat="server" Text="Horario" Visible="False"></asp:Label>
                                    <asp:DropDownList ID="DropDownList4" runat="server" Visible="False" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Seleccione una hora" ControlToValidate="DropDownList4"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="False" CausesValidation="True"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="Button1" runat="server" Text="Re Agenda" Visible="False" OnClick="Button1_Click1" />
                                </div>
                             </form>
    
						</header>
						<span class="image featured"></span>
					&nbsp;</section>

					<section class="box special features">
						<div class="features-row">
							<section>
								<span class="icon major fa-bolt accent2"></span>
								<h3>Cardio</h3>
								<p>Contamos con los mejores especialistas para cuidar de su corazón </p>
                               
							</section>
							<section>
								<span class="icon major fa-area-chart accent3"></span>
								<h3>Dentista</h3>
								<p>Una sonrisa sana y franca puede abrirle muchas puertas ademas de brindar incontables beneficios a la salud, con nosotros se encuentra en las mejores manos.</p>
							</section>
						</div>
						<div class="features-row">
							<section>
								<span class="icon major fa-cloud accent4"></span>
								<h3>Pedriatria</h3>
								<p>Sabemos que sus hijos son lo mas imporante, brindamos cuidado como si fueran nuestros.</p>
							</section>
							<section>
								<span class="icon major fa-lock accent5"></span>
								<h3>Oncologia</h3>
								<p>Equipo especializado y los mejores profesionales para que uste se ponga en nuestras manos en este dificil momento.</p>
							</section>
						</div>
					</section>

					<div class="row">
						<div class="6u 12u(narrower)">

						</div>
					</div>

				</section>

			<!-- CTA -->
				<section id="cta">

					<h2>Su bienestar es nuestra meta</h2>
					<p>Si desea conocer información sobre nosotros ingrese su correo</p>

					<form>
						<div class="row uniform 50%">
							<div class="8u 12u(mobilep)">
								<input type="email" name="email" id="email" placeholder="Email Address" />
							</div>
							<div class="4u 12u(mobilep)">
								<input type="submit" value="Sign Up" class="fit" />
							</div>
						</div>
					</form>

				</section>

			<!-- Footer -->
				<footer id="footer">
					<ul class="icons">
						<li><a href="#" class="icon fa-twitter"><span class="label">Twitter</span></a></li>
						<li><a href="#" class="icon fa-facebook"><span class="label">Facebook</span></a></li>
						<li><a href="#" class="icon fa-instagram"><span class="label">Instagram</span></a></li>
						<li><a href="#" class="icon fa-github"><span class="label">Github</span></a></li>
						<li><a href="#" class="icon fa-dribbble"><span class="label">Dribbble</span></a></li>
						<li><a href="#" class="icon fa-google-plus"><span class="label">Google+</span></a></li>
					</ul>
					<ul class="copyright">
						<li>&copy; Clinica San Angel. All rights reserved.</li>
					</ul>
				</footer>

		</div>


		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/jquery.dropotron.min.js"></script>
			<script src="assets/js/jquery.scrollgress.min.js"></script>
			<script src="assets/js/skel.min.js"></script>
			<script src="assets/js/util.js"></script>
			<!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
			<script src="assets/js/main.js"></script>
    

</body>
</html>


