﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18444.
// 
#pragma warning disable 1591

namespace BCR.SIGANEM.wsaIndicadores.SiganemIndicadoresWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SiganemIndicadoresWSSoap", Namespace="http://bancobcr.com/")]
    public partial class SiganemIndicadoresWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ValidaConexionWebServiceIndicadoresOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConsultaIndicadorEconomicoTCOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConsultaIndicadorEconomicoIPCOperationCompleted;
        
        private System.Threading.SendOrPostCallback RegistraEjecucionServicioBitacoraOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SiganemIndicadoresWS() {
            this.Url = global::BCR.SIGANEM.wsaIndicadores.Properties.Settings.Default.SiganemIndicadoresWS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ValidaConexionWebServiceIndicadoresCompletedEventHandler ValidaConexionWebServiceIndicadoresCompleted;
        
        /// <remarks/>
        public event ConsultaIndicadorEconomicoTCCompletedEventHandler ConsultaIndicadorEconomicoTCCompleted;
        
        /// <remarks/>
        public event ConsultaIndicadorEconomicoIPCCompletedEventHandler ConsultaIndicadorEconomicoIPCCompleted;
        
        /// <remarks/>
        public event RegistraEjecucionServicioBitacoraCompletedEventHandler RegistraEjecucionServicioBitacoraCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bancobcr.com/ValidaConexionWebServiceIndicadores", RequestNamespace="http://bancobcr.com/", ResponseNamespace="http://bancobcr.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ValidaConexionWebServiceIndicadores() {
            object[] results = this.Invoke("ValidaConexionWebServiceIndicadores", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ValidaConexionWebServiceIndicadoresAsync() {
            this.ValidaConexionWebServiceIndicadoresAsync(null);
        }
        
        /// <remarks/>
        public void ValidaConexionWebServiceIndicadoresAsync(object userState) {
            if ((this.ValidaConexionWebServiceIndicadoresOperationCompleted == null)) {
                this.ValidaConexionWebServiceIndicadoresOperationCompleted = new System.Threading.SendOrPostCallback(this.OnValidaConexionWebServiceIndicadoresOperationCompleted);
            }
            this.InvokeAsync("ValidaConexionWebServiceIndicadores", new object[0], this.ValidaConexionWebServiceIndicadoresOperationCompleted, userState);
        }
        
        private void OnValidaConexionWebServiceIndicadoresOperationCompleted(object arg) {
            if ((this.ValidaConexionWebServiceIndicadoresCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ValidaConexionWebServiceIndicadoresCompleted(this, new ValidaConexionWebServiceIndicadoresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bancobcr.com/ConsultaIndicadorEconomicoTC", RequestNamespace="http://bancobcr.com/", ResponseNamespace="http://bancobcr.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public RespuestaEntidad[] ConsultaIndicadorEconomicoTC(IndicadorEconomicoEntidad _entidad, BitacorasEntidad _bitacora) {
            object[] results = this.Invoke("ConsultaIndicadorEconomicoTC", new object[] {
                        _entidad,
                        _bitacora});
            return ((RespuestaEntidad[])(results[0]));
        }
        
        /// <remarks/>
        public void ConsultaIndicadorEconomicoTCAsync(IndicadorEconomicoEntidad _entidad, BitacorasEntidad _bitacora) {
            this.ConsultaIndicadorEconomicoTCAsync(_entidad, _bitacora, null);
        }
        
        /// <remarks/>
        public void ConsultaIndicadorEconomicoTCAsync(IndicadorEconomicoEntidad _entidad, BitacorasEntidad _bitacora, object userState) {
            if ((this.ConsultaIndicadorEconomicoTCOperationCompleted == null)) {
                this.ConsultaIndicadorEconomicoTCOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultaIndicadorEconomicoTCOperationCompleted);
            }
            this.InvokeAsync("ConsultaIndicadorEconomicoTC", new object[] {
                        _entidad,
                        _bitacora}, this.ConsultaIndicadorEconomicoTCOperationCompleted, userState);
        }
        
        private void OnConsultaIndicadorEconomicoTCOperationCompleted(object arg) {
            if ((this.ConsultaIndicadorEconomicoTCCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultaIndicadorEconomicoTCCompleted(this, new ConsultaIndicadorEconomicoTCCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bancobcr.com/ConsultaIndicadorEconomicoIPC", RequestNamespace="http://bancobcr.com/", ResponseNamespace="http://bancobcr.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public RespuestaEntidad[] ConsultaIndicadorEconomicoIPC(IndicadorEconomicoEntidad _entidad, BitacorasEntidad _bitacora) {
            object[] results = this.Invoke("ConsultaIndicadorEconomicoIPC", new object[] {
                        _entidad,
                        _bitacora});
            return ((RespuestaEntidad[])(results[0]));
        }
        
        /// <remarks/>
        public void ConsultaIndicadorEconomicoIPCAsync(IndicadorEconomicoEntidad _entidad, BitacorasEntidad _bitacora) {
            this.ConsultaIndicadorEconomicoIPCAsync(_entidad, _bitacora, null);
        }
        
        /// <remarks/>
        public void ConsultaIndicadorEconomicoIPCAsync(IndicadorEconomicoEntidad _entidad, BitacorasEntidad _bitacora, object userState) {
            if ((this.ConsultaIndicadorEconomicoIPCOperationCompleted == null)) {
                this.ConsultaIndicadorEconomicoIPCOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConsultaIndicadorEconomicoIPCOperationCompleted);
            }
            this.InvokeAsync("ConsultaIndicadorEconomicoIPC", new object[] {
                        _entidad,
                        _bitacora}, this.ConsultaIndicadorEconomicoIPCOperationCompleted, userState);
        }
        
        private void OnConsultaIndicadorEconomicoIPCOperationCompleted(object arg) {
            if ((this.ConsultaIndicadorEconomicoIPCCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConsultaIndicadorEconomicoIPCCompleted(this, new ConsultaIndicadorEconomicoIPCCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bancobcr.com/RegistraEjecucionServicioBitacora", RequestNamespace="http://bancobcr.com/", ResponseNamespace="http://bancobcr.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int RegistraEjecucionServicioBitacora(BitacorasEntidad _bitacora) {
            object[] results = this.Invoke("RegistraEjecucionServicioBitacora", new object[] {
                        _bitacora});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void RegistraEjecucionServicioBitacoraAsync(BitacorasEntidad _bitacora) {
            this.RegistraEjecucionServicioBitacoraAsync(_bitacora, null);
        }
        
        /// <remarks/>
        public void RegistraEjecucionServicioBitacoraAsync(BitacorasEntidad _bitacora, object userState) {
            if ((this.RegistraEjecucionServicioBitacoraOperationCompleted == null)) {
                this.RegistraEjecucionServicioBitacoraOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRegistraEjecucionServicioBitacoraOperationCompleted);
            }
            this.InvokeAsync("RegistraEjecucionServicioBitacora", new object[] {
                        _bitacora}, this.RegistraEjecucionServicioBitacoraOperationCompleted, userState);
        }
        
        private void OnRegistraEjecucionServicioBitacoraOperationCompleted(object arg) {
            if ((this.RegistraEjecucionServicioBitacoraCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RegistraEjecucionServicioBitacoraCompleted(this, new RegistraEjecucionServicioBitacoraCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bancobcr.com/")]
    public partial class IndicadorEconomicoEntidad {
        
        private string indicadorField;
        
        private string fechaInicioField;
        
        private string fechaFinalField;
        
        private string nombreBancoField;
        
        private string subNivelesField;
        
        private string indMetodoInsercionField;
        
        private System.Nullable<System.DateTime> fechaIngresoField;
        
        private string codUsuarioIngresoField;
        
        private string desUsuarioIngresoField;
        
        private System.Nullable<System.DateTime> fechaUltimaModificacionField;
        
        private string codUsuarioUltimaModificacionField;
        
        private string desUsuarioUltimaModificacionField;
        
        /// <remarks/>
        public string Indicador {
            get {
                return this.indicadorField;
            }
            set {
                this.indicadorField = value;
            }
        }
        
        /// <remarks/>
        public string FechaInicio {
            get {
                return this.fechaInicioField;
            }
            set {
                this.fechaInicioField = value;
            }
        }
        
        /// <remarks/>
        public string FechaFinal {
            get {
                return this.fechaFinalField;
            }
            set {
                this.fechaFinalField = value;
            }
        }
        
        /// <remarks/>
        public string NombreBanco {
            get {
                return this.nombreBancoField;
            }
            set {
                this.nombreBancoField = value;
            }
        }
        
        /// <remarks/>
        public string SubNiveles {
            get {
                return this.subNivelesField;
            }
            set {
                this.subNivelesField = value;
            }
        }
        
        /// <remarks/>
        public string IndMetodoInsercion {
            get {
                return this.indMetodoInsercionField;
            }
            set {
                this.indMetodoInsercionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> FechaIngreso {
            get {
                return this.fechaIngresoField;
            }
            set {
                this.fechaIngresoField = value;
            }
        }
        
        /// <remarks/>
        public string CodUsuarioIngreso {
            get {
                return this.codUsuarioIngresoField;
            }
            set {
                this.codUsuarioIngresoField = value;
            }
        }
        
        /// <remarks/>
        public string DesUsuarioIngreso {
            get {
                return this.desUsuarioIngresoField;
            }
            set {
                this.desUsuarioIngresoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> FechaUltimaModificacion {
            get {
                return this.fechaUltimaModificacionField;
            }
            set {
                this.fechaUltimaModificacionField = value;
            }
        }
        
        /// <remarks/>
        public string CodUsuarioUltimaModificacion {
            get {
                return this.codUsuarioUltimaModificacionField;
            }
            set {
                this.codUsuarioUltimaModificacionField = value;
            }
        }
        
        /// <remarks/>
        public string DesUsuarioUltimaModificacion {
            get {
                return this.desUsuarioUltimaModificacionField;
            }
            set {
                this.desUsuarioUltimaModificacionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bancobcr.com/")]
    public partial class RespuestaEntidad {
        
        private int valorEstadoField;
        
        private string valorEstadoCadenaField;
        
        private int valorErrorField;
        
        /// <remarks/>
        public int ValorEstado {
            get {
                return this.valorEstadoField;
            }
            set {
                this.valorEstadoField = value;
            }
        }
        
        /// <remarks/>
        public string ValorEstadoCadena {
            get {
                return this.valorEstadoCadenaField;
            }
            set {
                this.valorEstadoCadenaField = value;
            }
        }
        
        /// <remarks/>
        public int ValorError {
            get {
                return this.valorErrorField;
            }
            set {
                this.valorErrorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bancobcr.com/")]
    public partial class BitacorasEntidad {
        
        private int codAccionField;
        
        private int codModuloField;
        
        private int codEmpresaField;
        
        private string codSistemaField;
        
        private string codUsuarioField;
        
        private string datoActualizadoField;
        
        private string datoEliminadoField;
        
        private string datoNuevoField;
        
        private string desRegistroField;
        
        /// <remarks/>
        public int CodAccion {
            get {
                return this.codAccionField;
            }
            set {
                this.codAccionField = value;
            }
        }
        
        /// <remarks/>
        public int CodModulo {
            get {
                return this.codModuloField;
            }
            set {
                this.codModuloField = value;
            }
        }
        
        /// <remarks/>
        public int CodEmpresa {
            get {
                return this.codEmpresaField;
            }
            set {
                this.codEmpresaField = value;
            }
        }
        
        /// <remarks/>
        public string CodSistema {
            get {
                return this.codSistemaField;
            }
            set {
                this.codSistemaField = value;
            }
        }
        
        /// <remarks/>
        public string CodUsuario {
            get {
                return this.codUsuarioField;
            }
            set {
                this.codUsuarioField = value;
            }
        }
        
        /// <remarks/>
        public string DatoActualizado {
            get {
                return this.datoActualizadoField;
            }
            set {
                this.datoActualizadoField = value;
            }
        }
        
        /// <remarks/>
        public string DatoEliminado {
            get {
                return this.datoEliminadoField;
            }
            set {
                this.datoEliminadoField = value;
            }
        }
        
        /// <remarks/>
        public string DatoNuevo {
            get {
                return this.datoNuevoField;
            }
            set {
                this.datoNuevoField = value;
            }
        }
        
        /// <remarks/>
        public string DesRegistro {
            get {
                return this.desRegistroField;
            }
            set {
                this.desRegistroField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void ValidaConexionWebServiceIndicadoresCompletedEventHandler(object sender, ValidaConexionWebServiceIndicadoresCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ValidaConexionWebServiceIndicadoresCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ValidaConexionWebServiceIndicadoresCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void ConsultaIndicadorEconomicoTCCompletedEventHandler(object sender, ConsultaIndicadorEconomicoTCCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultaIndicadorEconomicoTCCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultaIndicadorEconomicoTCCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public RespuestaEntidad[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((RespuestaEntidad[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void ConsultaIndicadorEconomicoIPCCompletedEventHandler(object sender, ConsultaIndicadorEconomicoIPCCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConsultaIndicadorEconomicoIPCCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConsultaIndicadorEconomicoIPCCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public RespuestaEntidad[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((RespuestaEntidad[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void RegistraEjecucionServicioBitacoraCompletedEventHandler(object sender, RegistraEjecucionServicioBitacoraCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RegistraEjecucionServicioBitacoraCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RegistraEjecucionServicioBitacoraCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591