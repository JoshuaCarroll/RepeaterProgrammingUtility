---


---

<h1 id="n5jlc-repeater-programming-utility">N5JLC Repeater Programming Utility</h1>
<p><a href="http://forthebadge.com"><img src="http://forthebadge.com/images/badges/contains-technical-debt.svg" alt="forthebadge"></a>
<a href="http://forthebadge.com"><img src="http://forthebadge.com/images/badges/powered-by-electricity.svg" alt="forthebadge"></a></p>
<p>A Windows desktop application that can be used to program any radio repeater controller that accepts <a href="https://en.wikipedia.org/wiki/Dual-tone_multi-frequency_signaling">DTMF</a> tones for programming.</p>
<p>Given a serial interface (such as a <a href="http://www.tigertronics.com/signalnk.htm">TigerLink USB</a>), it will automatically activate the <a href="https://en.wikipedia.org/wiki/Push-to-talk">PTT</a> on your radio.  If you don’t have one, then you can use the <a href="https://en.wikipedia.org/wiki/Voice-operated_switch">VOX feature</a> of your radio to send the commands.  The program will also automatically identify for you using text-to-speech.</p>
<p><img src="https://raw.githubusercontent.com/JoshuaCarroll/RepeaterProgrammingUtility/screenshots/screenshot3.png" alt="Screenshot of the N5JLC Repeater Programming Utility with several lines of repeater programming code."></p>
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
<p>You could dial it by hand, but if you get a single digit wrong you have to start over again. (<em>If this hasn’t happened to you yet, take it from me… it sucks.</em>)</p>
<p>This utility can key-up the radio, identify with your call sign, send each line, unkey between each line, and identify again at the end.</p>
<h2 id="installation--updates">Installation &amp; updates</h2>
<p>Follow these steps to install the program:</p>
<ol>
<li>Browse to <a href="http://www.n5jlc.com/radio_tools/repeater_programming_utility/">http://www.n5jlc.com/radio_tools/repeater_programming_utility/</a>.</li>
<li>Click <strong>Install</strong>.</li>
</ol>
<p>The program will automatically look for an updated version if there is an Internet connection when the program is opened.  If an update is available then the user will be asked if they want to install it.</p>
<h2 id="support">Support</h2>
<p>This is open-source, free software.  This typically means, and is true in this case, that it is community supported.  If you find a bug, check to see if there is already an issue open to address it before you submit one.  If you have a suggestion please open an issue and share your idea.</p>
<h2 id="contributing">Contributing</h2>
<p>You can contribute to this project by using the program and providing feedback, submitting issues, or by assisting in the programming and submitting pull requests.  In either case, please read the <a href="CONTRIBUTING.md">contributing page</a> for instructions.</p>
<h2 id="credits">Credits</h2>
<ul>
<li>Thanks to my dad, <a href="https://www.qrz.com/db/n5gc">N5GC</a> for introducing me to both programming and ham radio - interests that respectively fill and empty my wallet.</li>
<li>Many thanks for <a href="https://www.qrz.com/db/n5qlc">N5QLC</a> and <a href="https://www.qrz.com/db/k5tel">K5TEL</a> who trusted me to program the <a href="https://cauhf.org/arlinks-system/">AR Links System</a> hub controller - the experience of which was the driving force behind creating this utility.</li>
<li><em>Icons8-Windows-8-Industry-Radio-Tower.ico</em> created by <a href="http://icons8.com">icons8.com</a> and used under <a href="http://icons8.com/license/">this license</a>.</li>
</ul>

