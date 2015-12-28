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

Public Class EnvironVar

    Public Shared PATH_EXPORTACION_MODELOS = "C:\Modelos"
    'Path donde se exportan los modelos si se invoca al metodo GenerarModelos

    Public Shared PATH_IMAGENES = "C:\Imagenes"
    'Path donde se almacenan las imagenes de las placas y carteles

    Public Shared PATH_MATERIALES = "C:\Materiales"
    'Path donde se almacenan las texturas de los materiales de las señales

    Public Shared TEXTURA_NO_ENCONTRADA = "NOT_FOUND.JPG"
    'Nombre de la textura que se mostrará en caso de no encontrarse la imagen de la señal

End Class
