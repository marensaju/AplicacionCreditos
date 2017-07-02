<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="NuevoCliente.aspx.cs" Inherits="COPEUI.NuevoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >

    <link href="css/toast2.css" rel="stylesheet"/>
    <link href="css/toast3.css" rel="stylesheet"/>
    <script type="text/javascript" >
        function myFunction() {
            var x = document.getElementById("snackbar")
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }
    </script>
    <script type="text/javascript" >
        function myFunction2() {
            var x = document.getElementById("snackbar2")
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }
    </script>


    <!--pugins-->
      <script type="text/javascript">
          $(document).ready(function () {

              $('.tagsinput').tagsinput({
                  tagClass: 'label label-primary'
              });

              var $image = $(".image-crop > img")
              $($image).cropper({
                  aspectRatio: 1.618,
                  preview: ".img-preview",
                  done: function (data) {
                      // Output the result data for cropping image.
                  }
              });

              var $inputImage = $("#inputImage");
              if (window.FileReader) {
                  $inputImage.change(function () {
                      var fileReader = new FileReader(),
                              files = this.files,
                              file;

                      if (!files.length) {
                          return;
                      }

                      file = files[0];

                      if (/^image\/\w+$/.test(file.type)) {
                          fileReader.readAsDataURL(file);
                          fileReader.onload = function () {
                              $inputImage.val("");
                              $image.cropper("reset", true).cropper("replace", this.result);
                          };
                      } else {
                          showMessage("Please choose an image file.");
                      }
                  });
              } else {
                  $inputImage.addClass("hide");
              }

              $("#download").click(function () {
                  window.open($image.cropper("getDataURL"));
              });

              $("#zoomIn").click(function () {
                  $image.cropper("zoom", 0.1);
              });

              $("#zoomOut").click(function () {
                  $image.cropper("zoom", -0.1);
              });

              $("#rotateLeft").click(function () {
                  $image.cropper("rotate", 45);
              });

              $("#rotateRight").click(function () {
                  $image.cropper("rotate", -45);
              });

              $("#setDrag").click(function () {
                  $image.cropper("setDragMode", "crop");
              });

              $('#data_1 .input-group.date').datepicker({
                  todayBtn: "linked",
                  keyboardNavigation: false,
                  forceParse: false,
                  calendarWeeks: true,
                  autoclose: true
              });

              $('#data_2 .input-group.date').datepicker({
                  startView: 1,
                  todayBtn: "linked",
                  keyboardNavigation: false,
                  forceParse: false,
                  autoclose: true,
                  format: "dd/mm/yyyy"
              });

              $('#data_3 .input-group.date').datepicker({
                  startView: 2,
                  todayBtn: "linked",
                  keyboardNavigation: false,
                  forceParse: false,
                  autoclose: true
              });

              $('#data_4 .input-group.date').datepicker({
                  minViewMode: 1,
                  keyboardNavigation: false,
                  forceParse: false,
                  autoclose: true,
                  todayHighlight: true
              });

              $('#data_5 .input-daterange').datepicker({
                  keyboardNavigation: false,
                  forceParse: false,
                  autoclose: true
              });

              var elem = document.querySelector('.js-switch');
              var switchery = new Switchery(elem, { color: '#1AB394' });

              var elem_2 = document.querySelector('.js-switch_2');
              var switchery_2 = new Switchery(elem_2, { color: '#ED5565' });

              var elem_3 = document.querySelector('.js-switch_3');
              var switchery_3 = new Switchery(elem_3, { color: '#1AB394' });

              $('.i-checks').iCheck({
                  checkboxClass: 'icheckbox_square-green',
                  radioClass: 'iradio_square-green'
              });

              $('.demo1').colorpicker();

              var divStyle = $('.back-change')[0].style;
              $('#demo_apidemo').colorpicker({
                  color: divStyle.backgroundColor
              }).on('changeColor', function (ev) {
                  divStyle.backgroundColor = ev.color.toHex();
              });

              $('.clockpicker').clockpicker();

              $('input[name="daterange"]').daterangepicker();

              $('#reportrange span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));

              $('#reportrange').daterangepicker({
                  format: 'MM/DD/YYYY',
                  startDate: moment().subtract(29, 'days'),
                  endDate: moment(),
                  minDate: '01/01/2012',
                  maxDate: '12/31/2015',
                  dateLimit: { days: 60 },
                  showDropdowns: true,
                  showWeekNumbers: true,
                  timePicker: false,
                  timePickerIncrement: 1,
                  timePicker12Hour: true,
                  ranges: {
                      'Today': [moment(), moment()],
                      'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                      'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                      'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                      'This Month': [moment().startOf('month'), moment().endOf('month')],
                      'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                  },
                  opens: 'right',
                  drops: 'down',
                  buttonClasses: ['btn', 'btn-sm'],
                  applyClass: 'btn-primary',
                  cancelClass: 'btn-default',
                  separator: ' to ',
                  locale: {
                      applyLabel: 'Submit',
                      cancelLabel: 'Cancel',
                      fromLabel: 'From',
                      toLabel: 'To',
                      customRangeLabel: 'Custom',
                      daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
                      monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                      firstDay: 1
                  }
              }, function (start, end, label) {
                  console.log(start.toISOString(), end.toISOString(), label);
                  $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
              });

              $(".select2_demo_1").select2();
              $(".select2_demo_2").select2();
              $(".select2_demo_3").select2({
                  placeholder: "Select a state",
                  allowClear: true
              });


              $(".touchspin1").TouchSpin({
                  buttondown_class: 'btn btn-white',
                  buttonup_class: 'btn btn-white'
              });

              $(".touchspin2").TouchSpin({
                  min: 0,
                  max: 100,
                  step: 0.1,
                  decimals: 2,
                  boostat: 5,
                  maxboostedstep: 10,
                  postfix: '%',
                  buttondown_class: 'btn btn-white',
                  buttonup_class: 'btn btn-white'
              });

              $(".touchspin3").TouchSpin({
                  verticalbuttons: true,
                  buttondown_class: 'btn btn-white',
                  buttonup_class: 'btn btn-white'
              });

              $('.dual_select').bootstrapDualListbox({
                  selectorMinimalHeight: 160
              });


          });

          $('.chosen-select').chosen({ width: "100%" });

          $("#ionrange_1").ionRangeSlider({
              min: 0,
              max: 5000,
              type: 'double',
              prefix: "$",
              maxPostfix: "+",
              prettify: false,
              hasGrid: true
          });

          $("#ionrange_2").ionRangeSlider({
              min: 0,
              max: 10,
              type: 'single',
              step: 0.1,
              postfix: " carats",
              prettify: false,
              hasGrid: true
          });

          $("#ionrange_3").ionRangeSlider({
              min: -50,
              max: 50,
              from: 0,
              postfix: "°",
              prettify: false,
              hasGrid: true
          });

          $("#ionrange_4").ionRangeSlider({
              values: [
                  "January", "February", "March",
                  "April", "May", "June",
                  "July", "August", "September",
                  "October", "November", "December"
              ],
              type: 'single',
              hasGrid: true
          });

          $("#ionrange_5").ionRangeSlider({
              min: 10000,
              max: 100000,
              step: 100,
              postfix: " km",
              from: 55000,
              hideMinMax: true,
              hideFromTo: false
          });

          $(".dial").knob();

          var basic_slider = document.getElementById('basic_slider');

          noUiSlider.create(basic_slider, {
              start: 40,
              behaviour: 'tap',
              connect: 'upper',
              range: {
                  'min': 20,
                  'max': 80
              }
          });

          var range_slider = document.getElementById('range_slider');

          noUiSlider.create(range_slider, {
              start: [40, 60],
              behaviour: 'drag',
              connect: true,
              range: {
                  'min': 20,
                  'max': 80
              }
          });

          var drag_fixed = document.getElementById('drag-fixed');

          noUiSlider.create(drag_fixed, {
              start: [40, 60],
              behaviour: 'drag-fixed',
              connect: true,
              range: {
                  'min': 20,
                  'max': 80
              }
          });


    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="snackbar">Cliente Registrado exitosamente :) </div>
    <div id="snackbar2">Ha ocurrido un error con los datos o al subir la imagen!! :(</div>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

       
   
    <!--Contenido-->
     <div class="wrapper wrapper-content animated fadeInRight">

            <div class="row">
                <div class="col-lg-7">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Registro de nuevo cliente <small>Verifique todos los campos antes de finalizar.</small></h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#">Config option 1</a>
                                    </li>
                                    <li><a href="#">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            <div class="form-horizontal"> 

                            
                                <div class="form-group"><label class="col-sm-2 control-label">Nombres*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextPrimerNombre" placeholder="Primer nombre" CssClass="form-control required" required="" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextSegundoNombre" placeholder="Segundo nombre (Opcional)" CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                </div>



                                <div class="hr-line-dashed"></div>

                                <div class="form-group"><label class="col-sm-2 control-label">Apellidos*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextPrimerApellido"  placeholder="Primer apellido" CssClass=" form-control required" required="" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextSegundoApellido" placeholder="Segundo apellido del (Opcional)" CssClass="form-control" runat="server"></asp:TextBox>
                                                
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                
                                <div class="hr-line-dashed"></div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                          <div class="form-group"><label class="col-sm-2 control-label">Soy*</label>
                                    <div class="col-sm-9">


                                        <div class="radio  radio-inline">
                                           
                                            <asp:RadioButton ID="RadioButton1"  GroupName="eligo" runat="server" AutoPostBack="True" />
                                            <label for="inlineRadio1"> Hombre </label>
                                        </div>
                                        <div class="radio radio-inline">
                                            <asp:RadioButton ID="RadioButton2"  GroupName="eligo" runat="server" AutoPostBack="True" />
                                            <label for="inlineRadio2"> Mujer </label>
                                        </div>

                                    </div>
                                    </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                      
                                   
                                

                                <div class="hr-line-dashed"></div>
                                <div class="form-group"><label class="col-sm-2 control-label">DPI*</label>

                                    <div class="col-sm-9">
                                    <div class="row">
                                            <div class="col-md-6">    
                                                <asp:TextBox ID="TextDPI" CssClass="form-control required" data-mask="9999-99999-9999" placeholder="2332-72054-1202" required="" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextExtendido" CssClass="form-control required" placeholder="Extendido en"  required="" runat="server"></asp:TextBox>
                                            </div>
                                             </div>
                                        </div>
                                </div>

                                <div class="hr-line-dashed"></div>


                                <div class="form-group"><label class="col-sm-2 control-label">Estado civil*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                            <asp:TextBox ID="TextEstadoCivil" placeholder="Estado civil del cliente" CssClass="form-control required" required="" runat="server"></asp:TextBox>
                                       </div>
                                             </div>
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>
                                <div class="form-group"><label class="col-sm-2 control-label">Correo Electronico*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                            <asp:TextBox ID="TextCorreo" placeholder="Estado civil del cliente" CssClass="form-control required" runat="server"></asp:TextBox>
                                       </div>
                                             </div>
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>


                                <div class="form-group"><label class="col-sm-2 control-label">Profesión u oficio*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextProfesion" placeholder="Profesión u oficio" required="" CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>


                                <div class="form-group"><label class="col-sm-2 control-label">Fecha de nacimiento*</label>

                                    <div class="col-sm-9">
                                        <div class="row">

                                             <div class="col-md-12">
                                                 
                                              <div class="form-group" id="data_1">
                                                   <div class="input-group date">
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    <asp:TextBox ID="TextNacimiento" CssClass="form-control" value="01/01/2017" runat="server"></asp:TextBox>  

                                </div>
                                              </div>


                                          
                                             
                                             </div>

                                        </div>
                                    </div>
                                </div>


                                <div class="hr-line-dashed"></div>


                                <div class="form-group"><label class="col-sm-2 control-label">Número de teléfono *</label>

                                    <div class="col-sm-9">
                                        <div class="row">

                                             <div class="col-md-12">
                                                 <asp:TextBox ID="TextTelefonoPersonal"  required="" CssClass="form-control required" data-mask="9999-9999" placeholder="5285-5355" runat="server"></asp:TextBox>
                                             </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>

                                 <div class="form-group"><label class="col-sm-2 control-label">Región*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextDepartamento" placeholder="Departamento" required="" CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="TextMunicipio" placeholder="Municipio" required="" CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>
                               <div class="form-group"><label class="col-sm-2 control-label">Domicilio exacto*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextDomicilio" required="" placeholder="Dirreción exacta del cliente" CssClass="form-control required " runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>



                                <div class="hr-line-dashed"></div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                         <div class="form-group"><label class="col-sm-2 control-label">Vivo en*</label>
                                    <div class="col-sm-9">


                                        <div class="radio  radio-inline">
                                            <asp:RadioButton ID="RadioButton3" GroupName="elegir" runat="server" AutoPostBack="True" />
                                            <label for="inlineRadio3"> Casa propia </label>
                                        </div>
                                        <div class="radio radio-inline">
                                            <asp:RadioButton ID="RadioButton4" GroupName="elegir" runat="server" AutoPostBack="True" />
                                            <label for="inlineRadio4"> Casa alquilada </label>
                                        </div>

                                    </div>
                                    </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                
                                       

                                    
                                

                                 <div class="hr-line-dashed"></div>
                               <div class="form-group"><label class="col-sm-2 control-label">Teléfono residencial*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextTelefonoResidencial" required=""  CssClass="form-control required" data-mask="9999-9999" placeholder="7930-4424" runat="server"></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                                <div class="hr-line-dashed"></div>
                                <div class="form-group"><label class="col-sm-2 control-label">Fotografia*</label>
                                    <div class="col-sm-9">
                                    <div class="col-md-12">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>
                                        </div>
                                    
                                </div>


                                <div class="hr-line-dashed"></div>
                                
                            </div>
                        </div>
                    </div>
                </div>


                <!--Otra columan-->
    
                <div class="col-lg-5">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Localización <small>Verifique todos los campos antes de finalizar.</small></h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                           </div>
                        </div>
                        <div class="ibox-content">
                  <div  class="form-horizontal">
                      <!--
                               <div class="form-group"><label class="col-sm-2 control-label">Código*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextCodigo"  CssClass="form-control" placeholder="#1001QT" Enabled="false"  runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            <div class="hr-line-dashed"></div> -->



                            <h3>
                                Empleo
                            </h3>
                            <p>
                                Datos relacionados con el empleo del cliente.
                            </p>




                                <div class="hr-line-dashed"></div>
                               <div class="form-group"><label class="col-sm-2 control-label">Donde trabaja*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextTrabajo" required="" placeholder="Empresa o lugar de trabajo " CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>
                               <div class="form-group"><label class="col-sm-2 control-label">Dirección*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextDirTrabajo" required="" placeholder="Dirección del trabajo " CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>
                               <div class="form-group"><label class="col-sm-2 control-label">Teléfono*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextTelefonoTra" required="" CssClass="form-control required" data-mask="9999-9999" placeholder="7930-4425" runat="server"></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                </div>


                                <div class="hr-line-dashed"></div>
                               <div class="form-group"><label class="col-sm-2 control-label">Tiempo*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextTiempoTra" required="" placeholder="Tiempo de trabajar en empresa o negocio"  CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                </div>


                            <div class="hr-line-dashed"></div>
                      <div class="form-group"><label class="col-sm-2 control-label">Observación*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:TextBox ID="TextObservaciones" placeholder="Observaciones"  CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                      <div class="hr-line-dashed"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Siguiente columna-->

                <div class="col-lg-5">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5>Referencias personales <small>Verifique todos los campos antes de finalizar.</small></h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                           </div>
                        </div>
                        <div class="ibox-content">
                            <div  class="form-horizontal">

                               <h3>
                                Referencias personales
                            </h3>
                            <p>
                                Datos relacionados con conocidos del cliente.
                            </p>

                                <div class="hr-line-dashed"></div>

                                <div class="form-group"><label class="col-sm-2 control-label">No. 1*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-md-4">
                                                
                                                <asp:TextBox ID="TextRef1" required="" placeholder="Nombres y apellidos"  CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="TextRef2" required="" placeholder="Dirección"  CssClass="form-control " runat="server"></asp:TextBox>
           
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="TextRef3" required="" placeholder="Teléfono"  CssClass="form-control " runat="server"></asp:TextBox>

                                            </div>

                                        </div>
                                    </div>
                                </div>

                            <div class="hr-line-dashed"></div>

                                <div class="form-group"><label class="col-sm-2 control-label">No. 2*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                             <div class="col-md-4">
                                                
                                                <asp:TextBox ID="TextRef4" placeholder="Nombres y apellidos"  CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="TextRef5" placeholder="Dirección"  CssClass="form-control " runat="server"></asp:TextBox>
           
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="TextRef6" placeholder="Teléfono"  CssClass="form-control " runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="hr-line-dashed"></div>

                                <div class="form-group"><label class="col-sm-2 control-label">No. 3*</label>

                                    <div class="col-sm-9">
                                        <div class="row">
                                             <div class="col-md-4">
                                                
                                                <asp:TextBox ID="TextRef7" placeholder="Nombres y apellidos"  CssClass="form-control required" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="TextRef8" placeholder="Dirección"  CssClass="form-control " runat="server"></asp:TextBox>
           
                                            </div>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="TextRef9" placeholder="Teléfono"  CssClass="form-control " runat="server"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-5">

                    <div class="form-group">
                                    <div class="col-md-4 ">
                                        <button class="btn btn-white" type="submit">Cancelar</button>
                                       
                                        
                                    
                                </div>
                    
                        <div class="col-md-4 ">
                             <asp:Button ID="Button1"  CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="Button1_Click" />
                             </div>
                 </div>


      </div>
     </div>
          
        
    <!--Fin Contenido--> 
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>

</asp:Content>
