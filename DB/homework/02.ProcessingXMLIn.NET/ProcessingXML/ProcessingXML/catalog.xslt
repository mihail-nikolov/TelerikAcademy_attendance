<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" version='1.0' encoding='UTF-8' indent="yes"/>

  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
</xsl:text>
    <html>
      <body>
        <h2>My Albums Collection</h2>
        <table border="1">
          <tr bgcolor="#CCCCCC">
            <th align="center">Name</th>
            <th align="center">Artist</th>
            <th align="center">Year</th>
            <th align="center">Producer</th>
            <th align="center">Price</th>
            <th align="center">Songs</th>
          </tr>
          <xsl:for-each select="catalogue/album">
            <tr>
              <td align="center">
                <xsl:value-of select="name"/>
              </td>
              <td align="center">
                <xsl:value-of select="artist"/>
              </td>
              <td align="center">
                <xsl:value-of select="year"/>
              </td>
              <td align="center">
                <xsl:value-of select="producer"/>
              </td>
              <td align="center">
                <xsl:value-of select="price"/>
              </td>
              <td align="left">
                <xsl:for-each select="songs/song">
                  <div>
                    <xsl:value-of select="title"/>
                    <span> - </span>
                    <xsl:value-of select="duration"/>
                  </div>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
