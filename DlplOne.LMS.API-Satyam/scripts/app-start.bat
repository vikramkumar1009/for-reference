copy D:\mkboss\appSettings.json  C:\inetpub\wwwroot\nrl\net6.0\publish 
copy D:\mkboss\web.Config  C:\inetpub\wwwroot\nrl\net6.0\publish 
copy D:\mkboss\qms\global.json  C:\inetpub\wwwroot\nrl\net6.0\publish 
%windir%\syswow64\inetsrv\appcmd start site /site.name:NrlHealth  
%windir%\syswow64\inetsrv\appcmd start apppool /apppool.name:NrlHealth  