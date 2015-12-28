'GeoRoadSign - Visualizador de señalización 3D
'Copyright (C) 2010  Javier Santos Paniego
'web: http://georoadsign.sourceforge.net/


'This program is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or 
'(at your option) any later version.

'This program is distributed in the hope that it will be useful, 
'but WITHOUT ANY WARRANTY; without even the implied warranty of 
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the 
'GNU General Public License for more details.

'You should have received a copy of the GNU General Public License 
'along with this program.  If not, see http://www.gnu.org/licenses/.

Imports Normalizacion.Rotacion
Imports System.Windows

Public Class PosicionGPS

    'Atributos
    Private latitud As Double = 0.0
    Private longitud As Double = 0.0

    'Constructores
    Public Sub New()
        Me.latitud = 0.0
        Me.longitud = 0.0
    End Sub
    Public Sub New(ByVal latitud As Double, _
                   ByVal longitud As Double)
        Me.latitud = latitud
        Me.longitud = longitud
    End Sub
    'Funciones GET
    Public Function GetLatitud() As Double
        Return Me.latitud
    End Function
    Public Function GetLongitud() As Double
        Return Me.longitud
    End Function
    'Procedimientos SET
    Public Sub SetLatitud(ByVal latitud As Double)
        Me.latitud = latitud
    End Sub
    Public Sub SetLongitud(ByVal longitud As Double)
        Me.longitud = longitud
    End Sub
    'Resto de Subprogramas
    Public Shared Function UTM_to_WGS84(ByVal coordenada As Punto3D) As PosicionGPS
        Return GoogleLatLong(coordenada.GetX, coordenada.GetY, True)
    End Function
    Private Shared Function GoogleLatLong(ByVal Vx As Double, _
                                   ByVal Vy As Double, _
                                   ByVal VNorte As Boolean) As PosicionGPS

        '*******************************************************
        'FUNCIÓN IMPLEMENTADA POR RENATO NATALI - renato@satlink.com 
        'Adaptada para la clase "PosicionGPS".
        '*******************************************************

        'Input: Vx, Vy coordenadas en ED50 Huso 30
        'Ouput: GoogleLatLong.X = Latitud en WGS84 y GoogleLatLong.Y = Longitud en WGS84

        Dim Vuso As Integer = 30
        Dim EjeMenor As Double, EjeMayor As Double, Excentricidad As Double, Excentric2 As Double, Excent2cuad As Double, RadPolar As Double
        EjeMayor = 6378388
        EjeMenor = 6356911.946
        Excentricidad = Math.Round(Math.Sqrt(EjeMayor ^ 2 - EjeMenor ^ 2) / EjeMayor, 9)
        Excentric2 = Math.Round(Math.Sqrt(EjeMayor ^ 2 - EjeMenor ^ 2) / EjeMenor, 9)
        Excent2cuad = Math.Round(Excentric2 ^ 2, 9)
        RadPolar = (EjeMayor ^ 2) / EjeMenor
        Dim MerCentral As Integer, SurEcuador As Double
        Dim Fi As Double, Ni As Double, A As Double, A1 As Double, A2 As Double
        Dim J2 As Double, J4 As Double, J6 As Double
        Dim Alfa As Double, Beta As Double, Gamma As Double
        Dim Bfi As Double, B As Double, Zeta As Double, Xi As Double
        Dim Eta As Double, DeltaLambda As Double, SenHipXi As Double, Tau As Double
        Dim HexaLong As Double, FiRad As Double, HexaLat As Double
        Dim Pi As Double = Math.Round(Math.PI, 9)
        MerCentral = 6 * Vuso - 183
        SurEcuador = Vy
        If VNorte = False Then
            SurEcuador = SurEcuador - 10000000
        End If
        Fi = Math.Round(SurEcuador / (6366197.724 * 0.9996), 9)
        Ni = Math.Round((RadPolar / (1 + Excent2cuad * Math.Cos(Fi) ^ 2) ^ 0.5) * 0.9996, 3)
        A = Math.Round((Vx - 500000) / Ni, 9)
        A1 = Math.Round(Math.Sin(2 * Fi), 9)
        A2 = Math.Round(A1 * Math.Cos(Fi) ^ 2, 9)
        J2 = Math.Round(Fi + (A1 / 2), 9)
        J4 = Math.Round((3 * J2 + A2) / 4, 9)
        J6 = Math.Round(((5 * J4 + A2 * (Math.Cos(Fi)) ^ 2)) / 3, 9)
        Alfa = Math.Round(0.75 * Excent2cuad, 9)
        Beta = Math.Round((5 / 3) * Alfa ^ 2, 9)
        Gamma = Math.Round((35 / 27) * Alfa ^ 3, 12)
        Bfi = Math.Round(0.9996 * RadPolar * (Fi - (Alfa * J2) + (Beta * J4) - (Gamma * J6)), 1)
        B = Math.Round((SurEcuador - Bfi) / Ni, 9)
        Zeta = Math.Round(Excent2cuad * (A ^ 2) / 2 * Math.Cos(Fi) ^ 2, 12)
        Xi = Math.Round(A * (1 - Zeta / 3), 9)
        Eta = Math.Round(B * (1 - Zeta) + Fi, 9)
        SenHipXi = Math.Round((Math.Exp(Xi) - Math.Exp(-Xi)) / 2, 9)
        DeltaLambda = Math.Round(Math.Atan(SenHipXi / Math.Cos(Eta)), 9)
        Tau = Math.Round(Math.Atan(Math.Cos(DeltaLambda) * Math.Tan(Eta)), 9)
        HexaLong = Math.Round(DeltaLambda / Math.PI * 180 + MerCentral, 9)
        FiRad = Math.Round(Fi + (1 + Excent2cuad * Math.Cos(Fi) ^ 2 - 1.5 * Excent2cuad * Math.Sin(Fi) * Math.Cos(Fi) * (Tau - Fi)) * (Tau - Fi), 9)
        HexaLat = Math.Round(FiRad / Math.PI * 180, 9)
        Dim W As Double, x As Double, F As String
        F = IIf(VNorte = True, "N", "S")
        x = HexaLat
        W = HexaLong
        Dim AR16 As Double, AS16 As Double, AT16 As Double, AU16 As Double, AV16 As Double, AW16 As Double
        AR16 = 6378388
        AS16 = 6356911.94613
        AT16 = Math.Sqrt(AR16 ^ 2 - AS16 ^ 2) / AR16
        AU16 = Math.Sqrt(AR16 ^ 2 - AS16 ^ 2) / AS16
        AV16 = AU16 ^ 2
        AW16 = (AR16 ^ 2) / AS16
        Dim Y As Double, Z As Double
        Y = W * Math.PI / 180
        Z = x * Math.PI / 180
        Dim AA As Double
        AA = Fix((W / 6) + 31)
        Dim AB As Double
        AB = 6 * AA - 183
        Dim AC As Double
        AC = Y - ((AB * Math.PI) / 180)
        Dim AD As Double
        AD = Math.Cos(Z) * Math.Sin(AC)
        Dim AE As Double
        AE = (1 / 2) * Math.Log((1 + AD) / (1 - AD))
        Dim AF As Double
        AF = Math.Atan((Math.Tan(Z)) / Math.Cos(AC)) - Z
        Dim AG As Double
        AG = (AW16 / (1 + AV16 * (Math.Cos(Z)) ^ 2) ^ (1 / 2)) * 0.9996
        Dim AH As Double
        AH = (AV16 / 2) * AE ^ 2 * (Math.Cos(Z)) ^ 2
        Dim AI As Double
        AI = Math.Sin(2 * Z)
        Dim AJ As Double
        AJ = AI * (Math.Cos(Z)) ^ 2
        Dim AK As Double
        AK = Z + (AI / 2)
        Dim AL As Double
        AL = ((3 * AK) + AJ) / 4
        Dim AM As Double
        AM = (5 * AL + AJ * (Math.Cos(Z)) ^ 2) / 3
        Dim AN As Double
        AN = (3 / 4) * AV16
        Dim AO As Double
        AO = (5 / 3) * AN ^ 2
        Dim AP As Double
        AP = (35 / 27) * AN ^ 3
        Dim AQ As Double
        AQ = 0.9996 * AW16 * (Z - (AN * AK) + (AO * AL) - (AP * AM))
        Dim AR As Double, AT As Double
        AR = AA
        A2 = AE * AG * (1 + AH / 3) + 500000
        AT = IIf(F = "S", AF * AG * (1 + AH) + AQ + 10000000, AF * AG * (1 + AH) + AQ)
        Dim AX As Double, AY As Double, AZ As Double
        AX = A2
        AY = AT
        AZ = AR
        Dim BE As Double, BF As Double, BG As Double, BH As String, BI As Double
        BE = AX
        BF = AY
        BG = AZ
        BH = F
        BI = 771.76
        Dim BJ As Double, BK As Double, BL As Double, BM As Double, BN As Double, BO As Double
        BJ = 6378388
        BK = 6356911.94613
        BL = Math.Sqrt(BJ ^ 2 - BK ^ 2) / BJ
        BM = Math.Sqrt(BJ ^ 2 - BK ^ 2) / BK
        BN = BM ^ 2
        BO = (BJ ^ 2) / BK
        Dim BZ As Double
        BZ = IIf(F = "S", BF - 10000000, BF)
        Dim CA As Double
        CA = (BZ) / (6366197.724 * 0.9996)
        Dim CB As Double
        CB = (BO / (1 + BN * (Math.Cos(CA)) ^ 2) ^ (1 / 2)) * 0.9996
        Dim CC As Double
        CC = (BE - 500000) / CB
        Dim CN As Double
        CN = ((BN * CC ^ 2) / 2) * (Math.Cos(CA)) ^ 2
        Dim CO As Double
        CO = CC * (1 - (CN / 3))
        Dim CQ As Double
        CQ = (Math.Exp(CO) - Math.Exp(-CO)) / 2
        Dim CI As Double
        CI = (3 / 4) * BN
        Dim CD As Double
        CD = Math.Sin(2 * CA)
        Dim CF As Double
        CF = CA + (CD / 2)
        Dim CJ As Double
        CJ = (5 / 3) * (CI) ^ 2
        Dim CE As Double
        CE = CD * (Math.Cos(CA)) ^ 2
        Dim CG As Double
        CG = (3 * CF + CE) / 4
        Dim CK As Double
        CK = (35 / 27) * (CI) ^ 3
        Dim CH As Double
        CH = (5 * CG + CE * (Math.Cos(CA)) ^ 2) / 3
        Dim CL As Double
        CL = 0.9996 * BO * (CA - (CI * CF) + (CJ * CG) - (CK * CH))
        Dim CM As Double
        CM = (BZ - CL) / CB
        Dim CP As Double
        CP = CM * (1 - CN) + CA
        Dim CR As Double
        CR = Math.Atan(CQ / Math.Cos(CP))
        Dim CS As Double
        CS = Math.Atan(Math.Cos(CR) * Math.Tan(CP))
        Dim BV As Double, BW As Double, BX As Double, BY As Double
        BX = CA + (1 + BN * (Math.Cos(CA)) ^ 2 - (3 / 2) * BN * Math.Sin(CA) * Math.Cos(CA) * (CS - CA)) * (CS - CA)
        BW = (BX / Math.PI) * 180
        BY = 6 * BG - 183
        BV = (CR / Math.PI) * 180 + BY
        Dim CU As Double, CV As Double, CW As Double
        CU = BV
        CV = BW
        CW = BI
        Dim DC As Double
        DC = 6378388
        Dim DB As Double
        DB = CV / 180 * Math.PI
        Dim DD As Double
        DD = 6356911.94613
        Dim DE As Double
        DE = DC ^ 2 / Math.Sqrt(DC ^ 2 * (Math.Cos(DB)) ^ 2 + DD ^ 2 * (Math.Sin(DB)) ^ 2)
        Dim DA As Double
        DA = CU / 180 * Math.PI
        Dim CX As Double
        CX = (DE + CW) * Math.Cos(DB) * Math.Cos(DA)
        Dim CY As Double
        CY = (DE + CW) * Math.Cos(DB) * Math.Sin(DA)
        Dim DH As Double
        DH = CY
        Dim CZ As Double
        CZ = ((DD ^ 2 / DC ^ 2) * DE + CW) * Math.Sin(DB)
        Dim DI As Double
        DI = CZ
        Dim DJ As Double, DK As Double, DL As Double, DM As Double, DN As Double, D0 As Double, DP As Double
        DJ = -131.032
        DK = -163.354
        DL = -100.251
        DM = 1.2438
        DN = 0.0195
        D0 = 1.1436
        DP = 0.00000939
        Dim DG As Double
        DG = CX
        Dim DQ As Double
        DQ = DJ + ((1 + DP) * (DG + (DH * ToRadians(D0 / 60 / 60)) - (DI * ToRadians(DN / 60 / 60))))
        Dim DR As Double
        DR = DL + ((1 + DP) * (-(ToRadians(D0 / 60 / 60) * DG) + DH + (DI * ToRadians(DM / 60 / 60))))
        Dim DS As Double
        DS = DK + ((1 + DP) * ((DG * ToRadians(DN / 60 / 60)) - (DH * ToRadians(DM / 60 / 60)) + DI))
        Dim DU As Double, DV As Double, DW As Double, DX As Double
        DU = DQ
        DV = DR
        DW = DS
        Dim EA As Double, EB As Double
        EA = 6378137
        EB = 6356752.31424518
        Dim EE As Double
        EE = Math.Sqrt(DU ^ 2 + DV ^ 2)
        Dim EF As Double
        EF = Math.Atan((DW * EA) / (EE * EB))
        Dim ED As Double
        ED = (EA ^ 2 - EB ^ 2) / EB ^ 2
        Dim EC As Double
        EC = (EA ^ 2 - EB ^ 2) / EA ^ 2
        Dim EG As Double
        EG = Math.Atan((DW + ED * EB * (Math.Sin(EF)) ^ 3) / (EE - EC * EA * (Math.Cos(EF)) ^ 3))
        Dim EI As Double
        EI = EA ^ 2 / (Math.Sqrt(EA ^ 2 * (Math.Cos(EG)) ^ 2 + EB ^ 2 * (Math.Sin(EG)) ^ 2))
        Dim EJ As Double
        EJ = (EE / Math.Cos(EG)) - EI
        DX = EJ
        Dim EH As Double
        EH = Math.Atan(DV / DU)
        Dim DY As Double
        DY = EH * 180 / Math.PI
        Dim DZ As Double
        DZ = EG * 180 / Math.PI
        Dim EL As Double, EM As Double, EN As Double
        EL = DY
        EM = DZ
        EN = DX
        Dim ET As Double
        ET = EM * Math.PI / 180
        Dim ES As Double
        ES = EL * Math.PI / 180
        Dim EU As Double
        EU = Fix((EL / 6) + 31)
        Dim EV As Double
        EV = 6 * EU - 183
        Dim EW As Double
        EW = ES - ((EV * Math.PI) / 180)
        Dim EX As Double
        EX = Math.Cos(ET) * Math.Sin(EW)
        Dim EY As Double
        EY = (1 / 2) * Math.Log((1 + EX) / (1 - EX))
        Dim FC As Double
        FC = Math.Sin(2 * ET)
        Dim FM As Double
        FM = 6356752.31424518
        Dim FL As Double
        FL = 6378137
        Dim FQ As Double
        FQ = (FL ^ 2) / FM
        Dim FO As Double
        FO = Math.Sqrt(FL ^ 2 - FM ^ 2) / FM
        Dim FP As Double
        FP = FO ^ 2
        Dim FA As Double
        FA = (FQ / (1 + FP * (Math.Cos(ET)) ^ 2) ^ (1 / 2)) * 0.9996
        Dim FB As Double
        FB = (FP / 2) * EY ^ 2 * (Math.Cos(ET)) ^ 2
        Dim EO As Double
        EO = EY * FA * (1 + FB / 3) + 500000
        Dim EZ As Double
        EZ = Math.Atan((Math.Tan(ET)) / Math.Cos(EW)) - ET
        Dim FH As Double
        FH = (3 / 4) * FP
        Dim FE As Double
        FE = ET + (FC / 2)
        Fi = (5 / 3) * FH ^ 2
        Dim FD As Double
        FD = FC * (Math.Cos(ET)) ^ 2
        Dim FF As Double
        FF = ((3 * FE) + FD) / 4
        Dim FJ As Double
        FJ = (35 / 27) * FH ^ 3
        Dim FG As Double
        FG = (5 * FF + FD * (Math.Cos(ET)) ^ 2) / 3
        Dim FK As Double
        FK = 0.9996 * FQ * (ET - (FH * FE) + (Fi * FF) - (FJ * FG))
        Dim EP As Double
        EP = IIf(F = "S", EZ * FA * (1 + FB) + FK + 10000000, EZ * FA * (1 + FB) + FK)
        Dim GC As Double
        GC = IIf(F = "S", EP - 10000000, EP)
        Dim GD As Double
        GD = (GC) / (6366197.724 * 0.9996)
        Dim GE As Double
        GE = (FQ / (1 + FP * (Math.Cos(GD)) ^ 2) ^ (1 / 2)) * 0.9996
        Dim GF As Double
        GF = (EO - 500000) / GE
        Dim GQ As Double
        GQ = ((FP * GF ^ 2) / 2) * (Math.Cos(GD)) ^ 2
        Dim GR As Double
        GR = GF * (1 - (GQ / 3))
        Dim GT As Double
        GT = (Math.Exp(GR) - Math.Exp(-GR)) / 2
        Dim GL As Double
        GL = (3 / 4) * FP
        Dim GG As Double
        GG = Math.Sin(2 * GD)
        Dim GI As Double
        GI = GD + (GG / 2)
        Dim GM As Double
        GM = (5 / 3) * (GL) ^ 2
        Dim GH As Double
        GH = GG * (Math.Cos(GD)) ^ 2
        Dim GJ As Double
        GJ = (3 * GI + GH) / 4
        Dim GN As Double
        GN = (35 / 27) * (GL) ^ 3
        Dim GK As Double
        GK = (5 * GJ + GH * (Math.Cos(GD)) ^ 2) / 3
        Dim GO As Double
        GO = 0.9996 * FQ * (GD - (GL * GI) + (GM * GJ) - (GN * GK))
        Dim GP As Double
        GP = (GC - GO) / GE
        Dim GS As Double
        GS = GP * (1 - GQ) + GD
        Dim GU As Double
        GU = Math.Atan(GT / Math.Cos(GS))
        Dim EQ As Double
        EQ = EU
        Dim GB As Double
        GB = 6 * EQ - 183
        Dim FY As Double
        FY = (GU / Math.PI) * 180 + GB
        Dim HA As Double, HB As Double, HC As Double
        HA = EO
        HB = EP
        HC = EQ
        Dim GV As Double
        GV = Math.Atan(Math.Cos(GU) * Math.Tan(GS))
        Dim GA As Double
        GA = GD + (1 + FP * (Math.Cos(GD)) ^ 2 - (3 / 2) * FP * Math.Sin(GD) * Math.Cos(GD) * (GV - GD)) * (GV - GD)
        Dim FZ As Double
        FZ = (GA / Math.PI) * 180

        Return New PosicionGPS(FZ, FY)
    End Function

    Public Function ToUTM() As Punto3D
        'ED50 - en uso 30
        Dim EjeMenor As Double, EjeMayor As Double, Excentricidad As Double, Excentric2 As Double, Excent2cuad As Double, RadPolar As Double
        EjeMayor = 6378388   'WGS84 6378137
        EjeMenor = 6356911.946 'WGS84 6356752.314
        Excentricidad = Math.Sqrt(EjeMayor ^ 2 - EjeMenor ^ 2) / EjeMayor
        Excentric2 = Math.Sqrt(EjeMayor ^ 2 - EjeMenor ^ 2) / EjeMenor
        Excent2cuad = Excentric2 ^ 2
        RadPolar = (EjeMayor ^ 2) / EjeMenor


        Dim LongRad As Double, LatRad As Double
        Dim Huso As Integer, MeridianoHuso As Integer, DeltaLambda As Double
        Dim A As Double, Xi As Double, Eta As Double, Ni As Double, Zeta As Double
        Dim A1 As Double, A2 As Double, J2 As Double, J4 As Double, J6 As Double
        Dim Alfa As Double, Beta As Double, Gamma As Double, Bfi As Double
        Dim Vx As Double, Vy As Double

        LongRad = Me.longitud * Math.PI / 180
        LatRad = Me.latitud * Math.PI / 180
        Huso = 30
        MeridianoHuso = 6 * Huso - 183

        DeltaLambda = LongRad - (MeridianoHuso * Math.PI / 180)
        A = Math.Cos(LatRad) * Math.Sin(DeltaLambda)
        Xi = 0.5 * (Math.Log(1 + A) - Math.Log(1 - A))
        Eta = Math.Atan(Math.Tan(LatRad) / Math.Cos(DeltaLambda)) - LatRad
        Ni = (RadPolar / Math.Sqrt(1 + Excent2cuad * (Math.Cos(LatRad)) ^ 2)) * 0.9996
        Zeta = (Excent2cuad / 2) * (Xi ^ 2) * (Math.Cos(LatRad) ^ 2)
        A1 = Math.Sin(2 * LatRad)
        A2 = A1 * (Math.Cos(LatRad) ^ 2)
        J2 = LatRad + (A1 / 2)
        J4 = (3 * J2 + A2) / 4
        J6 = ((5 * J4 + A2 * (Math.Cos(LatRad)) ^ 2)) / 3
        Alfa = 0.75 * Excent2cuad
        Beta = 5 / 3 * (Alfa ^ 2)
        Gamma = (35 / 27) * (Alfa ^ 3)
        Bfi = 0.9996 * RadPolar * (LatRad - (Alfa * J2) + (Beta * J4) - (Gamma * J6))

        'Referir el X e Y a las coordenadas según USO 30 utilizado en cartografía
        Vx = Xi * Ni * (1 + Zeta / 3) + 500000
        Vy = Eta * Ni * (1 + Zeta) + Bfi

        Return New Punto3D(Vx, Vy, 0)
    End Function

    Public Function anguloConPosicion(ByVal pos As PosicionGPS) As Double
        'Devuelve Degrees
        Dim p1 As Punto3D = Me.ToUTM
        Dim p2 As Punto3D = pos.ToUTM()
        Dim v1 As New Vector(Integer.MaxValue, 0)
        Dim v2 As New Vector(p2.GetX - p1.GetX, p2.GetY - p1.GetY)

        Dim v As Double = Vector.AngleBetween(v1, v2)

        Return ToDegrees(ToAzimut(ToRadians(v)))

        '*************************
        'TEMP
        'Return 235.0
    End Function

    Public Function distanciaAPunto(ByVal pos As PosicionGPS) As Double
        'Devuelve metros

        Dim p1 As Punto3D = Me.ToUTM
        Dim p2 As Punto3D = pos.ToUTM
        Return p1.distanciaAPunto(p2)

        '*************************
        'TEMP
        'Return 2.0
    End Function
End Class
