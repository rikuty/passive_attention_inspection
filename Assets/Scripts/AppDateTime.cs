using UnityEngine;
using System;
using System.Collections.Generic;

public static class AppDateTime {
	
	private static DateTime lastServerDateTime;
	
	private static float lastResetTime;
	
	private static bool _isAppDateTimeSetted = false;
	public static bool isAppDateTimeSetted {
		get{
			return _isAppDateTimeSetted;
		}
	}

	public static DateTime Now {
		get{
			return GetDateTime();
		}
	}

	public static DateTime ResetAppDateTime( DateTime serverDateTime )
	{
		
//		string[] temp = serverDateString.Split( " "[0] );
//		string[] dateArray = temp[0].Split( "/"[0] );
//		string[] timeArray = temp[1].Split( ":"[0] );
//		
//		
//		lastServerDateTime = new DateTime(  int.Parse( dateArray[0] ) , int.Parse( dateArray[1] ) , int.Parse( dateArray[2] ) 
//																,  int.Parse( timeArray[0] ) , int.Parse( timeArray[1] ) , int.Parse( timeArray[2] )  );

		lastServerDateTime = serverDateTime;
		lastResetTime = Time.realtimeSinceStartup;
		
		_isAppDateTimeSetted = true;
		
		return lastServerDateTime;
			
	}
	
	
	 public static double GetPastSeconds()
	{
		
		return ( (double)Time.realtimeSinceStartup - (double)lastResetTime );
		
	}
		
	private static DateTime _GetDateTime()
	{
		
		return lastServerDateTime.AddSeconds( GetPastSeconds() );
			
	}
		
	public static DateTime GetLastServerDateTime()
	{
		return lastServerDateTime;
	}
	
	public static DateTime GetDateTime()
	{
		
		if( ! _isAppDateTimeSetted )
		{
//			AppDebug.LogWarning("AppDateTime is Not Initialized", AppDebug.LogType.AppData);
			return DateTime.Now;
		}
		
		return _GetDateTime();
		
	}

	private static DateTime UNIX_EPOCH =  new DateTime(1970, 1, 1, 0, 0, 0, 0);

	public static long GetUnixtime() {
		
		DateTime targetTime = _GetDateTime();
		
		if( ! _isAppDateTimeSetted ) {
//			AppDebug.LogError("AppDateTime is Not Initialized", AppDebug.LogType.AppData);
			return GetUnixtime (DateTime.Now);
		}

		return GetUnixtime (targetTime);

	}

	public static long GetUnixtime(DateTime dt){

		TimeSpan elapsedTime = dt.ToUniversalTime() - UNIX_EPOCH;

		return (long)elapsedTime.TotalSeconds;
	}

	public static DateTime GetDateTimeUnixtime(long unixtime){
		return UNIX_EPOCH.AddSeconds (unixtime).ToLocalTime();
	}

	
	public static string GetFormatString(string format)
	{
		
		DateTime targetTime = _GetDateTime();
		
		if( ! _isAppDateTimeSetted )
		{
//			AppDebug.LogError("AppDateTime is Not Initialized", AppDebug.LogType.AppData);
			return "";
		}
		
		return  targetTime.ToString( format );
		
	}
	
	/// <summary>
	/// 現在時刻が対象の時間内か
	/// </summary>
	/// <returns><c>true</c> if is with in the specified start end; otherwise, <c>false</c>.</returns>
	/// <param name="start">開始時刻.</param>
	/// <param name="end">終了時刻.</param>
	public static bool IsWithIn(DateTime start, DateTime end){
		return (IsPast(start) && !IsPast(end));
	}
	/// <summary>
	/// 現在時刻がターゲット時刻を過ぎているか
	/// </summary>
	/// <returns><c>true</c> if is past the specified target; otherwise, <c>false</c>.</returns>
	/// <param name="target">ターゲット時刻.</param>
	public static bool IsPast(DateTime target) {
		return (LimitTime(target).TotalSeconds <= 0f);
	}
	/// <summary>
	/// 現在時刻がターゲット時刻の未来か
	/// </summary>
	/// <returns><c>true</c> if is future the specified target; otherwise, <c>false</c>.</returns>
	/// <param name="target">ターゲット時刻.</param>
	public static bool IsFuture(DateTime target) {
		return !IsPast(target);
	}
	/// <summary>
	/// 現在時刻からターゲット時刻までの差分
	/// </summary>
	/// <returns>The time.</returns>
	/// <param name="target">ターゲット時刻.</param>
	public static TimeSpan LimitTime(DateTime target){
		return (target - GetDateTime());
	}

	/// 時刻から次の日付変更線のDateTimeを取得
	/// <param name="timeStamp">日付変更線のtimestamp</param>
	//


	/// <summary>
	/// 現在時刻から次の日付変更線のDateTimeを取得
	/// </summary>
	/// <returns>次の日付変更線のDateTime</returns>
	/// <param name="timeStamp">日付変更線のtimestamp</param>
	public static DateTime GetTommorow(float timeStamp = 0f){
		return GetTommorow (Now, timeStamp);
	}

	/// <summary>
	/// 時刻から次の日付変更線のDateTimeを取得
	/// </summary>
	/// <returns>次の日付変更線のDateTime</returns>
	/// <param name="now">元のDateTime</param>
	/// <param name="timeStamp">日付変更線のtimestamp</param>
	public static DateTime GetTommorow(DateTime now, float timeStamp = 0f){
		// 今日の0時
		DateTime today = now - now.TimeOfDay;
		// 今日の指定時刻
		DateTime tommorow = today.AddSeconds( timeStamp );
		if (now > tommorow) {
			tommorow = tommorow.AddDays (1f);
		}
		return tommorow;
	}

	/// <summary>
	/// 現在時刻から次の日付変更線(指定曜日)のDateTimeを取得
	/// </summary>
	/// <returns>次の日付変更線(指定曜日)のDateTime</returns>
	/// <param name="weekDay">指定曜日(sunday,monday,tuesday,wednesday,thursday,friday,saturday</param>
	/// <param name="timeStamp">日付変更線のtimestamp</param>
	public static DateTime GetNextWeekDay(string weekDay, float timeStamp = 0f){
		return GetNextWeekDay (Now, weekDay, timeStamp);
	}

	/// <summary>
	/// 時刻から次の日付変更線(指定曜日)のDateTimeを取得
	/// </summary>
	/// <returns>次の日付変更線(指定曜日)のDateTime</returns>
	/// <param name="now">Now.</param>
	/// <param name="weekDay">指定曜日(sunday,monday,tuesday,wednesday,thursday,friday,saturday</param>
	/// <param name="timeStamp">日付変更線のtimestamp</param>
	public static DateTime GetNextWeekDay(DateTime now, string weekDay, float timeStamp = 0f){
		return GetNextWeekDay (now, week [weekDay], timeStamp);
	}

	/// <summary>
	/// 時刻から次の日付変更線(指定曜日)のDateTimeを取得
	/// </summary>
	/// <returns>次の日付変更線(指定曜日)のDateTime</returns>
	/// <param name="targetDayOfWeek">Target day of week.</param>
	/// <param name="timeStamp">日付変更線のtimestamp</param>
	public static DateTime GetNextWeekDay(DayOfWeek targetDayOfWeek, float timeStamp = 0f){
		return GetNextWeekDay (Now, targetDayOfWeek, timeStamp);
	}

	/// <summary>
	/// 時刻から次の日付変更線(指定曜日)のDateTimeを取得
	/// </summary>
	/// <returns>次の日付変更線(指定曜日)のDateTime</returns>
	/// <param name="now">Now.</param>
	/// <param name="targetDayOfWeek">Target day of week.</param>
	/// <param name="timeStamp">日付変更線のtimestamp</param>
	public static DateTime GetNextWeekDay(DateTime now, DayOfWeek targetDayOfWeek, float timeStamp = 0f){
		DateTime tommorow = GetTommorow(now, timeStamp);
		if (tommorow.DayOfWeek.Equals (targetDayOfWeek) && tommorow.DayOfWeek.Equals (now.DayOfWeek)) {
			return tommorow;
		}
		return tommorow.AddDays (((int)(DayOfWeek.Saturday - tommorow.DayOfWeek + targetDayOfWeek) % 7) + 1);
	}

	private static Dictionary<string, DayOfWeek> week = new Dictionary<string, DayOfWeek> () {
		{"sunday",DayOfWeek.Sunday},
		{"monday",DayOfWeek.Monday},
		{"tuesday",DayOfWeek.Thursday},
		{"wednesday",DayOfWeek.Wednesday},
		{"thursday",DayOfWeek.Thursday},
		{"friday",DayOfWeek.Friday},
		{"saturday",DayOfWeek.Saturday},
	};
}
