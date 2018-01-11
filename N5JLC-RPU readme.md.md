---


---

<h1 id="n5jlc-repeater-programming-utility">N5JLC Repeater Programming Utility</h1>
<p><a href="http://forthebadge.com"><img src="http://forthebadge.com/images/badges/contains-technical-debt.svg" alt="forthebadge"></a>
<a href="http://forthebadge.com"><img src="http://forthebadge.com/images/badges/winter-is-coming.svg" alt="forthebadge"></a>
<a href="http://forthebadge.com"><img src="http://forthebadge.com/images/badges/powered-by-electricity.svg" alt="forthebadge"></a></p>
<p>A Windows desktop application that can be used to program any radio repeater controller that accepts <a href="https://en.wikipedia.org/wiki/Dual-tone_multi-frequency_signaling">DTMF</a> tones for programming.</p>
<p>Given a serial interface (such as a <a href="http://www.tigertronics.com/signalnk.htm">TigerLink USB</a>), it will automatically activate the <a href="https://en.wikipedia.org/wiki/Push-to-talk">PTT</a> on your radio.  If you don’t have one, then you can use the <a href="https://en.wikipedia.org/wiki/Voice-operated_switch">VOX feature</a> of your radio to send the commands.  The program will also automatically identify for you using text-to-speech.</p>
<p><img src="https://raw.githubusercontent.com/JoshuaCarroll/RepeaterProgrammingUtility/screenshots/screenshot.png" alt="Screenshot of the N5JLC Repeater Programming Utility with several lines of repeater programming code."></p>
<h2 id="what">What?</h2>
<p><a href="http://www.arrl.org/what-is-amateur-radio">Amateur Radio</a> operators (aka <em>ham operators</em> or <em>hams</em>) use repeaters to basically re-broadcast a signal. Repeaters typically have a quality antenna, high power, and an elevated location.  This way, a ham radio operator using a small hand-held radio with 1 watt of power (typically a broadcast radius of roughly 2 miles) can be heard across an entire state.</p>
<h2 id="why">Why?</h2>
<p>The computer that runs a repeater, called a <em>controller</em>, has to be programmed. Initially this is done by being physically plugged into the controller.  However physically accessing a controller isn’t always easy because of distance, physical security, or other factors.  Because of this, many controllers are capable of being programmed over-the-air by using dial-tones (yes, just like the ones you hear when you dial the phone).</p>
<p>Dialing a single command isn’t a big deal.  But what happens when you need to completely rewrite a macro like this?</p>
<pre><code>053 503 038 
056 503 428
056 503 800
056 503 053 256 551
056 503 053 258 554
056 503 053 260 598 
056 503 053 261 599 
056 503 037 1 3 
056 503 036 394 239 301 437 395
010 503 92751
</code></pre>
<p>You could dial it by hand, but if you get a single digit wrong you have to start over again.</p>
<p>This utility can key-up the radio, identify with your call sign, send each line, unkey between each line, and identify again at the end.</p>
<h2 id="initial-installation--updates">Initial installation &amp; updates</h2>
<p>The only system prerequisite is .NET Framework v4.5, which is already installed on Windows computers that are regularly updated.  <s>If there is an Internet connection when the program is opened it will look for an update and, if one is available, prompt the user to install it.</s> (Coming soon)</p>
<h2 id="contributing">Contributing</h2>
<p>You can contribute to this project by using the program and providing feedback, submitting issues, or by assisting in the programming and submitting pull requests.  In either case, please read the <a href="CONTRIBUTING.md">contributing page</a> for instructions.</p>

