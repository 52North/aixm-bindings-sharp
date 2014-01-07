REM this compiles everything into one big .cs file

xsd.exe ..\..\gml\3.2.1\gml.xsd ..\..\xlink\1.0.0\xlinks.xsd ..\..\iso\19139\20070417\gmd\gmd.xsd ..\..\iso\19139\20070417\gco\gco.xsd ..\..\iso\19139\20070417\gss\gss.xsd ..\..\iso\19139\20070417\gts\gts.xsd ..\..\iso\19139\20070417\gsr\gsr.xsd AIXM_Features.xsd /classes /namespace:aero.aixm.v51
