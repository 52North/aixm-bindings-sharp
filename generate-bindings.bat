REM this compiles everything into one big .cs file

xsd.exe xsd\gml\3.2.1\gml.xsd xsd\xlink\1.0.0\xlinks.xsd xsd\iso\19139\20070417\gmd\gmd.xsd xsd\iso\19139\20070417\gco\gco.xsd xsd\iso\19139\20070417\gss\gss.xsd xsd\iso\19139\20070417\gts\gts.xsd xsd\iso\19139\20070417\gsr\gsr.xsd xsd\aixm\5.1\AIXM_Features.xsd /classes /namespace:aero.aixm.v51
