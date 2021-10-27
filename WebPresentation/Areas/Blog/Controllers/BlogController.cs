using Application.BlogApplication;
using Domain.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPresentation.Areas.Blog.Controllers
{
	//spDapa
//	USE[DBDAPA_SIB_DAPA]
//GO
///****** Object:  StoredProcedure [report].[SpReport110304]    Script Date: 03/08/1400 11:07:05 ق.ظ ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//ALTER PROCEDURE[report].[SpReport110304]
//	(
//   @SessionRoleUser INT,
//   @Id_Report INT,
//   @Id_Date SMALLINT,
//   @StartDate VARCHAR(10) = NULL,
//	@FinishDate VARCHAR(10) = NULL
//)
//AS
//BEGIN

//	DECLARE @GStartDate DATE = dbo.PersianToGregorian(@StartDate)
//	DECLARE @GFinishDate DATE = dbo.PersianToGregorian(@FinishDate)


//	DECLARE @AgeMin INT = NULL
//	DECLARE @AgeMinUnit VARCHAR(10) = NULL
//	DECLARE @AgeMax INT = NULL
//	DECLARE @AgeMaxUnit VARCHAR(10) = NULL
//	DECLARE @StateType INT = NULL
//	DECLARE @Id_RRole VARCHAR(3000) = NULL
//	DECLARE @IdRole VARCHAR(20) = NULL
//	DECLARE @Gender INT = NULL
//	DECLARE @RNetType VARCHAR(100) = NULL
//	DECLARE @FeedBackState VARCHAR(10) = NULL


//	DECLARE @RefWhere NVARCHAR(MAX)=''
//	DECLARE @UzWhere NVARCHAR(MAX) =' WHERE 1=1 '
//	DECLARE @RoleWhere NVARCHAR(MAX)=''
//	DECLARE @NetWhere NVARCHAR(MAX)=''
//	DECLARE @ReferalWhere NVARCHAR(MAX)=''
//	DECLARE @JOIN NVARCHAR(MAX)='' 
//	DECLARE @RoleJOIN NVARCHAR(MAX)='' 
//	DECLARE @NetJOIN NVARCHAR(MAX)=''
//	DECLARE @AgeMinD Date = NULL
//	DECLARE @AgeMaxD Date = NULL
//	DECLARE @ParamDefinition NVARCHAR(2000)



//	DECLARE @Condition NVARCHAR(MAX) = '{}'
//	SELECT @Condition = Condition FROM dbo.TblReportGeneratorInfo WHERE Id = @Id_Report

//	DECLARE @Prm TABLE (K VARCHAR(MAX), V NVARCHAR(MAX), T TINYINT)
//	INSERT INTO @Prm SELECT[Key], [Value], [Type] FROM OPENJSON(@Condition)

//	SELECT @Id_RRole = V FROM @Prm WHERE K = 'Id_RRole'
//	SELECT @IdRole = V FROM @Prm WHERE K = 'IdRole'
//	SELECT @AgeMin = V FROM @Prm WHERE K = 'AgeMin'
//	SELECT @AgeMinUnit = V FROM @Prm WHERE K = 'AgeMinUnit'
//	SELECT @AgeMax = V FROM @Prm WHERE K = 'AgeMax'
//	SELECT @AgeMaxUnit = V FROM @Prm WHERE K = 'AgeMaxUnit'
//	SELECT @StateType = V FROM @Prm WHERE K = 'BV_StateType'
//	SELECT @Gender = V FROM @Prm WHERE K = 'Gender'
//	SELECT @RNetType = V FROM @Prm WHERE K = 'RNetType'
//	SELECT @FeedBackState = V FROM @Prm WHERE K = 'FeedBackState'



//	SET @RefWhere = @RefWhere + ' AND  ReferralDate>=  @GStartDate '
//	SET @RefWhere = @RefWhere + ' AND ReferralDate <=  @GFinishDate '


//	IF @AgeMin IS NOT NULL
//	BEGIN
//		SELECT @AgeMinD = dbo.AddPersianDate(-@AgeMin, @AgeMinUnit, dbo.PersianToGregorian(@FinishDate))
//		SET @UzWhere = @UzWhere + ' AND UZ.BirthDateM <=  @AgeMinD '
//	END

//	IF @AgeMax IS NOT NULL
//	BEGIN
//		SELECT @AgeMaxD=dbo.AddPersianDate(-@AgeMax, @AgeMaxUnit, dbo.PersianToGregorian(@FinishDate))
//		SET @UzWhere = @UzWhere + ' AND UZ.BirthDateM > @AgeMaxD '
//	END
//	IF @Gender IS NOT NULL SET @UzWhere = @UzWhere + ' AND UZ.Gender=2 '
//	IF @StateType IS NOT NULL
//	BEGIN
//	IF @StateType<> 15 SET @RefWhere = @RefWhere + ' AND BV.StateType=@StateType '
//	IF @StateType = 15 SET @RefWhere = @RefWhere + ' AND BV.StateType <> 11 '
//	SET @JOIN = ' INNER JOIN TblReferralItems RefItm on RefItm.Id_Referral=Ref.Id

//				INNER JOIN TblFmlyUzrBasicVisit BV (NOLOCK) on RefItm.Id_BasicVisit= Bv.Id '
// 	END
//	IF  @Id_RRole IS NOT NULL OR @IdRole IS NOT NULL
//	BEGIN


//		SET @RoleJoin = @RoleJoin + ' INNER JOIN TblRoleUser Rol  on Rol.Id=Ref.Id_RoleUser

//									  INNER JOIN TblRoleUser RRol on RRol.Id= Ref.Id_RRoleUser '

//		IF @RoleWhere >0  

//		   SET @RoleWhere = @RoleWhere + ' WHERE Rol.Id_Role in (' + @IdRole + ') AND RRol.Id_Role in(' + @Id_RRole + ') '

//	END
//	IF  @RNetType IS NOT NULL
//	BEGIN
//	  SET @NetJOIN= @NetJOIN + ' INNER JOIN PrmNetWorkStructure PNS on PNS.Id=Ref.Id_RNetWork '

//	  SET @NetWhere = @NetWhere + ' WHERE  Id_NetworkStructureType in (' + @RNetType + ')  '

//	  IF @FeedBackState = 1

//		SET @NetWhere = @NetWhere + ' AND FeedBackState>0 '
//	END
//	DECLARE @Query NVARCHAR(MAX) = CONCAT('
//	 DELETE FROM dbo.IdxReportCache WHERE Id_Date = @Id_Date AND Id_Report = ', @Id_Report, '
//	; WITH Cte AS(
//		 SELECT
//		 Ref.Id_User IdUser, Ref.ReferralDate
//		 FROM TblReferral Ref 
//	'  ,@RoleJOIN , @JOIN ,@NetJOIN,

//		 @RefWhere, @NetWhere,
// 	')

//	 INSERT INTO dbo.IdxReportCache (Id_Date, Id_Report, Id_Network, Id_Param, Val1, Val2, Date_)
//	 SELECT
//		', @Id_Date, ',
// 		', @Id_Report, ',
//		 Id_Network,
//		 PS.Id_RegionType,
//		 SUM(CASE WHEN GENDER = 1 THEN 1 ELSE 0 END) Val1,
//		SUM(CASE WHEN GENDER = 2 THEN 1 ELSE 0 END) Val2,
//		GETDATE()
//	FROM
//		Cte
//		INNER JOIN TblUserInfo UZ WITH(NOLOCK) ON UZ.Id_User = Cte.IdUser
//	   INNER JOIN dbo.PrmNetworkStructure PS WITH (NOLOCK) ON UZ.Id_Network = PS.Id '
//		, @UzWhere,'


//   GROUP BY

//	   Id_Network, PS.Id_RegionType
//		')


//	   SET @ParamDefinition = '     

//	   @GStartDate DATE,
//	   @GFinishDate DATE,
//	   @AgeMinD DATE,
//	   @AgeMAXD DATE,
//	   @StateType INT,
//	   @Id_Date SMALLINT
//		'

//   PRINT @QUERY

//   EXEC sp_Executesql

//	   @Query, @ParamDefinition,
//	   @GStartDate ,
//	   @GFinishDate      ,
//	   @AgeMinD    ,
//	   @AgeMAXD    ,
//	   @StateType   ,
//	   @Id_Date

//	   END




	//[ApiController]
	//public class BlogController : Controller
	//{
	//    private readonly IBlogService _blogService;

	//    public BlogController(IBlogService blogService)
	//    {
	//        _blogService = blogService;
	//    }

	//    [HttpPost]
	//    [Route("/blog/GetBlogs")]
	//    public IActionResult GetBlogs(int id)
	//    {
	//        var entities=_blogService.GetAll();
	//        return Ok(entities.Result);
	//    }

	//    //[HttpPost]
	//    //[Route("/blog2")]
	//    //public IActionResult Post([FromBody] vmBlogInfo model)
	//    //{
	//    //    var entities = _blogService.Create(model);

	//    //    return Ok(entities.Result);
	//    //}

	//    [HttpPut]
	//    [Route("/blog")]
	//    public IActionResult Put(vmBlogInfo model)
	//    {
	//        var entities = _blogService.Update(model);

	//        return Ok(entities.Result);
	//    }



	//}
}
