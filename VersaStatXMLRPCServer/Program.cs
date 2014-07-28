using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using CookComputing.XmlRpc;

namespace VersaStatXMLRPCServer
{
    public interface IVersaStat
    {
        [XmlRpcMethod("FindNext")]
        int FindNext( int iStartIndex );
        /* returns the serial number of the next available instrument. 
         * The iStartIndex parameter is used if more than one instrument is attached to the USB. 
         * To request the Serial Number for the first instrument, iStartIndex should be 0.
         */

        [XmlRpcMethod("Connect")]
        bool Connect( int iSerialNumber );
        /* Connects to the instrument specified by the iSerialNumber parameter. 
         * Returns true if successful, false if not.
         */

        [XmlRpcMethod("Close")]
        void Close();
        /* Closes the connection to the instrument.
        */

        [XmlRpcMethod("GetSerialNumber")]
        string GetSerialNumber();
        /* Returns the serial number of the currently connected instrument.
        */

        [XmlRpcMethod("GetModel")]
        string GetModel();
        /* Returns the model of the currently connect instrument (ie VersaSTAT 3 – 400).
        */

        [XmlRpcMethod("GetOptions")]
        string GetOptions();
        /* Returns the options of the currently connected instrument (ie FRA).
        */

        [XmlRpcMethod("SetCellOn")]
        void SetCellOn();
        /* Turns the instruments Cell On
         */

        [XmlRpcMethod("SetCellOff")]
        void SetCellOff(); 
        /* Turns the instruments Cell Off */

        [XmlRpcMethod("SetCellExternal")]
        void SetCellExternal(); 
        /* Sets the instrument to use the External Cell
         */

        [XmlRpcMethod("SetCellInternal")]
        void SetCellInternal(); 
        /* Sets the instrument to use the Internal Cell
         */

        [XmlRpcMethod("SetModePotentiostat")]
        void SetModePotentiostat();
        /* Sets the instrument to potentiostatic mode
         */

        [XmlRpcMethod("SetModeGalvanostat")]
        void SetModeGalvanostat();
        /* Sets the instrument to galvanostat mode
         */

        [XmlRpcMethod("SetIRange_2A")]
        void SetIRange_2A(); 
        /* Sets the current range to 2A */

        [XmlRpcMethod("SetIRange_200mA")]
        void SetIRange_200mA();
        /* Sets the current range to 200mA */

        [XmlRpcMethod("SetIRange_20mA")]
        void SetIRange_20mA();
        /* Sets the current range to 20mA */

        [XmlRpcMethod("SetIRange_2mA")]
        void SetIRange_2mA();
        /* Sets the current range to 2mA
        */

        [XmlRpcMethod("SetIRange_200uA")]
        void SetIRange_200uA();
        /* Sets the current range to 200uA
        */

        [XmlRpcMethod("SetIRange_20uA")]
        void SetIRange_20uA();
        /* Sets the current range to 20uA 
        */

        [XmlRpcMethod("SetIRange_2uA")]
        void SetIRange_2uA();
        /* Sets the current range to 2uA
        */

        [XmlRpcMethod("SetIRange_200nA")]
        void SetIRange_200nA();
        /* Sets the current range to 200nA
        */

        [XmlRpcMethod("SetIRange_20nA")]
        void SetIRange_20nA();
        /* Sets the current range to 20nA (if instrument is able)
        */

        [XmlRpcMethod("SetIRange_4nA")]
        void SetIRange_4nA();
        /* Sets the current range to 4nA (if instrument is able)
        */

        [XmlRpcMethod("SetDCPotential")]
        void SetDCPotential( double fVoltage );
        /* Sets the output DC potential to the amount provided with the 
        * fVoltage parameter, in Volts. Note this value must be within the 
        * instruments capability.
        */

        [XmlRpcMethod("SetDCCurrent")]
        void SetDCCurrent( double fCurrent );
        /* 
        * Sets the output DC current to the amount provided with the fCurrent parameter, in Amps. Calling this method also changes to Galvanostat mode and sets the current range to the correct value. WARNING: Once cell is enabled after setting the DC current, do not change to potentiostatic mode or change the current range, these will affect the value being applied to the cell. 
        * Note this value must be within the instruments capability.
        */

        [XmlRpcMethod("SetACFrequency")]
        void SetACFrequency( double fFrequency );
        /* Sets the output AC Frequency to the value provided with the fFrequency parameter, 
        * in Hz. Note this value must be within the instruments capability.
        */

        [XmlRpcMethod("SetACAmplitude")]
        void SetACAmplitude( double fRMSAmplitude );
        /* Sets the output AC Amplitude to the value provided with the 
        * fRMSAmplitude parameter, in RMS Volts. Note this value must be within the 
        * instruments capabilities.
        */

        [XmlRpcMethod("SetACWaveformOn")]
        void SetACWaveformOn();
        /* Enables the AC Waveform
        */

        [XmlRpcMethod("SetACWaveformOff")]
        void SetACWaveformOff();
        /* Disables the AC Waveform
        */

        [XmlRpcMethod("UpdateStatus")]
        void UpdateStatus();
        /* This method retrieves the status information from the instrument 
        * (it also causes the instrument to auto-range the current if an experiment
        * sequence is not in progress). Call this prior to calling the status methods below.
        */

        [XmlRpcMethod("GetE")]
        double GetE();
        /* Returns the latest stored E value
        */

        [XmlRpcMethod("GetI")]
        double GetI();
        /* Returns the latest stored I value
        */

        [XmlRpcMethod("GetOverload")]
        int GetOverload();
        /* Returns the latest overload information. 0 indicates no overload, 
        * 1 indicates I (current) Overload, 2 indicates E, Power Amp or Thermal Overload has occurred.
        */

        [XmlRpcMethod("GetBoosterEnabled")]
        bool GetBoosterEnabled();
        /* Returns the status of the booster switch, if enabled, true is returned, otherwise false is returned.
        */

        [XmlRpcMethod("GetCellEnabled")]
        bool GetCellEnabled();
        /* Returns the status of the cell, if enabled, true is returned, otherwise false is returned.
        */

        [XmlRpcMethod("GetIRange")]
        string GetIRange();
        /* Returns the current range the instrument is on. 
        * Values will be either 2A, 200mA, 20mA, 2mA, 200uA, 20uA, 2uA, 200nA, 20nA or 4nA.
        */

        /*
        void SetIsolationModeOn() – For the VersaSTAT 3F ONLY
        void SetIsolationModeOff() – For the VersaSTAT 3F ONLY
        void SetACNotchFilter_None() - For the VersaSTAT 3F ONLY
        void SetACNotchFilter_50Hz() - For the VersaSTAT 3F ONLY
        void SetACNotchFilter_60Hz() - For the VersaSTAT 3F ONLY
        void SetACFilters_Normal() - For the VersaSTAT 3F ONLY
        void SetACFilters_Aggresive() - For the VersaSTAT 3F ONLY
        void SetACFilters_MoreAggressive() - For the VersaSTAT 3F ONLY
        */

        [XmlRpcMethod("SetAutoIRangeOn")]
        void SetAutoIRangeOn();
        /* Enables (default is enabled) automatic current ranging while an experiment is not running.
        */

        [XmlRpcMethod("SetAutoIRangeOff")]
        void SetAutoIRangeOff();
        /* Disables automatic current ranging while an experiment is not running. 
        * This is useful when wanting to apply a DC current in immediate mode.
        */

    }
    public class VersaStatServer : MarshalByRefObject, IVersaStat
    {
        public VersaStatServer()
        {
            checkInstrument();
        }

        static VersaSTATControl.Instrument V3_Instrument = null;

        private void checkInstrument(){
            if ( V3_Instrument == null) {
                V3_Instrument = new VersaSTATControl.Instrument();
            }
        }
        public string GetStateName(int stateNumber)
        {
            return stateNumber.ToString();
        }

        public int FindNext(int iStartIndex)
        {
            return V3_Instrument.FindNext(iStartIndex);
        }

        public bool Connect(int iSerialNumber)
        {
            return V3_Instrument.Connect(iSerialNumber);
        }

        public void Close()
        {
            V3_Instrument.Close();
        }

        public string GetSerialNumber()
        {
            return V3_Instrument.GetSerialNumber();
        }

        public string GetModel()
        {
            string s = V3_Instrument.GetModel();
            return s;
        }

        public string GetOptions()
        {
            return V3_Instrument.GetOptions();
        }

        public void SetCellOn()
        {
            V3_Instrument.Immediate.SetCellOn();
        }

        public void SetCellOff()
        {
            V3_Instrument.Immediate.SetCellOff();
        }

        public void SetCellExternal()
        {
            V3_Instrument.Immediate.SetCellExternal();
        }

        public void SetCellInternal()
        {
            V3_Instrument.Immediate.SetCellInternal();
        }

        public void SetModePotentiostat()
        {
            V3_Instrument.Immediate.SetModePotentiostat();
        }

        public void SetModeGalvanostat()
        {
            V3_Instrument.Immediate.SetModeGalvanostat();
        }

        public void SetIRange_2A()
        {
            V3_Instrument.Immediate.SetIRange_2A();
        }

        public void SetIRange_200mA()
        {
            V3_Instrument.Immediate.SetIRange_200mA();
        }

        public void SetIRange_20mA()
        {
            V3_Instrument.Immediate.SetIRange_20mA();
        }

        public void SetIRange_2mA()
        {
            V3_Instrument.Immediate.SetIRange_2mA();
        }

        public void SetIRange_200uA()
        {
            V3_Instrument.Immediate.SetIRange_200uA();
        }

        public void SetIRange_20uA()
        {
            V3_Instrument.Immediate.SetIRange_20uA();
        }

        public void SetIRange_2uA()
        {
            V3_Instrument.Immediate.SetIRange_2uA();
        }

        public void SetIRange_200nA()
        {
            V3_Instrument.Immediate.SetIRange_200nA();
        }

        public void SetIRange_20nA()
        {
            V3_Instrument.Immediate.SetIRange_20nA();
        }

        public void SetIRange_4nA()
        {
            V3_Instrument.Immediate.SetIRange_4nA();
        }

        public void SetDCPotential(double fVoltage)
        {
            V3_Instrument.Immediate.SetDCPotential((float)fVoltage);
        }

        public void SetDCCurrent(double fCurrent)
        {
            V3_Instrument.Immediate.SetDCCurrent((float)fCurrent);
        }

        public void SetACFrequency(double fFrequency)
        {
            V3_Instrument.Immediate.SetACFrequency((float)fFrequency);
        }

        public void SetACAmplitude(double fRMSAmplitude)
        {
            V3_Instrument.Immediate.SetACAmplitude((float)fRMSAmplitude);
        }

        public void SetACWaveformOn()
        {
            V3_Instrument.Immediate.SetACWaveformOn();
        }

        public void SetACWaveformOff()
        {
            V3_Instrument.Immediate.SetACWaveformOff();
        }

        public void UpdateStatus()
        {
            V3_Instrument.Immediate.UpdateStatus();
        }

        public double GetE()
        {
            return V3_Instrument.Immediate.GetE();
        }

        public double GetI()
        {
            return V3_Instrument.Immediate.GetI();
        }

        public int GetOverload()
        {
            return V3_Instrument.Immediate.GetOverload();
        }

        public bool GetBoosterEnabled()
        {
            return V3_Instrument.Immediate.GetBoosterEnabled();
        }

        public bool GetCellEnabled()
        {
            return V3_Instrument.Immediate.GetCellEnabled();
        }

        public string GetIRange()
        {
            return V3_Instrument.Immediate.GetIRange();
        }

        public void SetAutoIRangeOn()
        {
            V3_Instrument.Immediate.SetAutoIRangeOn();
        }

        public void SetAutoIRangeOff()
        {
            V3_Instrument.Immediate.SetCellOn();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string configFileName="VersaStatXMLRPCServer.exe.config";
            string uri = "VersaStatServer.rem";
            Console.WriteLine("Starting up uri " + uri + " using setting in " + configFileName);
            RemotingConfiguration.Configure(configFileName, false);
            RemotingConfiguration.RegisterWellKnownServiceType(
              typeof(VersaStatServer),
              uri,
              WellKnownObjectMode.Singleton);

            Console.WriteLine("To access from Jython enter the commands:");
            Console.WriteLine(">>>import xmlrpclib;");
            Console.WriteLine(">>>versaStat = xmlrpclib.ServerProxy(\"http://xxx:5678/VersaStatServer.rem\")");
            Console.WriteLine(">>>versaStat.Connect(versaStat.FindNext(0))");
            Console.WriteLine(">>>versaStat.Close()");
            Console.WriteLine();
            Console.WriteLine("Press to shutdown");
            Console.ReadLine();
        }
    }
}
