echo "stopping" 
%windir%\syswow64\inetsrv\appcmd stop apppool /apppool.name:NrlHealth  
%windir%\syswow64\inetsrv\appcmd stop site /site.name:NrlHealth 