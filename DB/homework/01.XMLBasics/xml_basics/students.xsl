<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:students="urn:students"
                xmlns:exams="urn:exams"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" version='1.0' encoding='UTF-8' indent="yes"/>

  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">
</xsl:text>
    <html>
      <body>
        <h1>Students</h1>
        <table bgcolor="#E0E0E0" cellspacing="2px" cellpadding="5px">
          <tr bgcolor="#EEEEEE">
            <td>
              <b>Name</b>
            </td>
            <td>
              <b>Sex</b>
            </td>
            <td>
              <b>Birth date</b>
            </td>
            <td>
              <b>Phone</b>
            </td>
            <td>
              <b>Email</b>
            </td>
            <td>
              <b>Course</b>
            </td>
            <td>
              <b>Specialty</b>
            </td>
            <td>
              <b>Faculty number</b>
            </td>
            <td>
              <b>Exams</b>
            </td>
          </tr>
          <xsl:for-each select="/students:students/students:student">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="sex"/>
              </td>
              <td>
                <xsl:value-of select="birth_date"/>
              </td>
              <td>
                <xsl:value-of select="phone"/>
              </td>
              <td>
                <xsl:value-of select="email"/>
              </td>
              <td>
                <xsl:value-of select="course"/>
              </td>
              <td>
                <xsl:value-of select="specialty"/>
              </td>
              <td>
                <xsl:value-of select="faculty_number"/>
              </td>
              <td align="left">
                <xsl:for-each select="exams:exams/exams:exam">
                  <div>
                    <xsl:value-of select="name"/>
                    <span> - </span>
                    <xsl:value-of select="tutor"/>
                    <span> - </span>
                    <xsl:value-of select="score"/>
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
