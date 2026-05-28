using System;
using System.Collections.Generic;

namespace CybersecurityChatbot.Services
{
    public class RandomResponseManager
    {
        private readonly Dictionary<string, string> _explanations;
        private readonly Dictionary<string, List<string>> _responses;
        private readonly Random _random = new Random();

        public RandomResponseManager()
        {
            _explanations = new Dictionary<string, string>
            {
                { "Passwords", "Passwords are your first line of defense against unauthorized access. A strong password acts like a complex lock that hackers cannot easily pick." },
                { "Malware", "Malware (malicious software) includes viruses, worms, and Trojans designed to damage, disrupt, or gain unauthorized access to your system." },
                { "Privacy", "Data privacy is about controlling how your personal information is collected, used, and shared by online services." },
                { "Phishing", "Phishing is a cyber attack where attackers disguise themselves as a trustworthy entity to trick you into revealing sensitive information." },
                { "Browsing", "Safe browsing involves recognizing secure websites and protecting your browser from malicious scripts and trackers." },
                { "Ransomware", "Ransomware is a type of malware that encrypts your files or locks you out of your device, demanding a ransom payment to restore access." },
                { "Social Engineering", "Social engineering relies on psychological manipulation, tricking you into making security mistakes or giving away confidential information." },
                { "Two-Factor Authentication", "Two-Factor Authentication (2FA) adds a second layer of security, requiring not just a password, but also a code sent to your phone or authenticator app." },
                { "Wi-Fi Security", "Wi-Fi security ensures that the wireless networks you connect to cannot be intercepted or snooped on by attackers." },
                { "Social Media", "Social media security involves protecting your personal profile from identity thieves and avoiding oversharing personal details." },
                { "Software Updates", "Software updates contain vital security patches that fix known vulnerabilities in the applications and operating systems you use." },
                { "Identity Theft", "Identity theft occurs when someone steals your personal information (like your ID or SSN) to commit fraud in your name." },
                { "Email Security", "Email security protects your inbox from spam, malicious attachments, and account takeovers." },
                { "Backups", "Backups are duplicate copies of your data stored separately, ensuring you can recover your files if your device is compromised or broken." },
                { "Mobile Security", "Mobile security protects smartphones and tablets from malicious apps, theft, and unauthorized access." },
                { "IoT & Smart Home", "IoT (Internet of Things) security involves protecting smart devices like cameras, thermostats, and smart speakers from being hacked." }
            };

            _responses = new Dictionary<string, List<string>>
            {
                { "Passwords", new List<string> { "Always use a mix of uppercase, lowercase, numbers, and symbols.", "Never reuse the same password across multiple sites.", "Consider using a password manager.", "Passphrases are often stronger and easier to remember than random characters.", "Use a password generator for high entropy.", "Rotate passwords for sensitive accounts occasionally.", "Avoid using dictionary words or sequential numbers." } },
                { "Malware", new List<string> { "Keep your antivirus updated to the latest signature database.", "Run regular full system scans.", "Don't ignore alerts from your security software.", "Be careful when plugging in unfamiliar USB drives.", "Avoid downloading pirated software or media.", "Ensure your security software is running in real-time.", "Scan email attachments before opening them." } },
                { "Privacy", new List<string> { "Review app permissions on your phone regularly.", "Use a VPN when connected to public Wi-Fi.", "Be mindful of what you share on social media.", "Clear your browser cookies and cache frequently.", "Use privacy-focused search engines like DuckDuckGo.", "Opt out of targeted advertising in your social media settings.", "Regularly audit connected third-party apps." } },
                { "Phishing", new List<string> { "Always check the sender's email address.", "Hover over links to see the real destination before clicking.", "Beware of urgent requests for personal information.", "If an offer seems too good to be true, it probably is.", "Type URLs manually instead of clicking links in emails.", "Look out for generic greetings like 'Dear Customer'.", "Contact the organization via phone if you receive a suspicious alert." } },
                { "Browsing", new List<string> { "Look for the padlock and HTTPS in the address bar.", "Keep your web browser updated.", "Use an ad-blocker or privacy extension.", "Don't download files from untrusted websites.", "Use a DNS filtering service to block malicious domains.", "Log out of sensitive accounts when you are finished using them.", "Consider using browser containers to isolate web activity." } },
                { "Ransomware", new List<string> { "Never pay the ransom — it doesn't guarantee your files back.", "Keep offline backups of your most important files.", "Don't open attachments from unknown senders.", "Patch your operating system promptly to avoid exploits.", "Disconnect an infected machine from the network immediately.", "Use cloud backup services that offer versioning to undo changes.", "Restrict admin privileges on your daily user account." } },
                { "Social Engineering", new List<string> { "Be wary of unsolicited phone calls claiming to be from IT or your bank.", "Verify identities through official channels before sharing data.", "Question urgent requests that pressure you to act fast.", "Don't post your daily schedule or vacation plans publicly.", "Shred sensitive documents before throwing them in the trash.", "Never yield to artificial pressure from a caller." } },
                { "Two-Factor Authentication", new List<string> { "Always enable 2FA on your email and banking accounts.", "Use authenticator apps instead of SMS when possible.", "Keep your backup 2FA codes in a safe physical location.", "Use hardware security keys for your most critical accounts.", "Print out and securely store your offline backup codes.", "Re-evaluate devices you have marked as 'trusted' periodically." } },
                { "Wi-Fi Security", new List<string> { "Avoid accessing banking accounts on public Wi-Fi.", "Change your home router's default password.", "Disable auto-connect to open Wi-Fi networks.", "Update your router's firmware periodically.", "Use WPA3 encryption if your network devices support it.", "Turn off your Wi-Fi when you do not need it to prevent tracking." } },
                { "Social Media", new List<string> { "Set your profiles to private.", "Watch out for quizzes that harvest your data.", "Be cautious of friend requests from strangers.", "Use a dedicated email address for social media accounts.", "Turn off location tagging on your posts and photos.", "Be selective about answering quizzes that ask personal questions." } },
                { "Software Updates", new List<string> { "Enable automatic updates for your OS and apps.", "Don't delay installing security patches.", "Uninstall software you no longer use.", "Enable automatic updates for your web browser.", "Check for firmware updates for your smart TVs and appliances.", "Restart your device after updating to ensure the patch is applied." } },
                { "Identity Theft", new List<string> { "Monitor your bank statements regularly.", "Shred documents that contain personal information.", "Set up fraud alerts with your credit bureau.", "Place a security freeze on your credit reports if you don't need new credit.", "Protect your ID number and only give it out when legally required.", "Review your health insurance statements for unrecognized claims." } },
                { "Email Security", new List<string> { "Never open attachments from unknown senders.", "Use email encryption for sensitive communications.", "Be cautious of unexpected password reset emails.", "Enable spam filters and mark suspicious emails as 'Junk'.", "Be wary of emails trying to convey a sense of panic regarding your account.", "Regularly clear out old emails containing sensitive personal data." } },
                { "Backups", new List<string> { "Follow the 3-2-1 rule: 3 copies, 2 media types, 1 offsite.", "Automate your backups so you don't forget.", "Test your backups regularly to ensure they work.", "Ensure your backup drives are not permanently connected to your PC.", "Encrypt your backups in case the physical drive is stolen.", "Document your restoration process so you know exactly what to do." } },
                { "Mobile Security", new List<string> { "Use a strong PIN or biometric lock.", "Only install apps from official app stores.", "Enable 'Find My Device' to allow remote wiping.", "Do not strictly rely on pattern locks; a strong alphanumeric PIN is better.", "Review which apps have access to your microphone and camera.", "Avoid jailbreaking or rooting your device." } },
                { "IoT & Smart Home", new List<string> { "Change default passwords on all smart devices.", "Put smart devices on a separate guest network.", "Disable features you don't use, like cameras or microphones.", "Disable UPnP on your router to stop devices from opening ports.", "If a smart device no longer receives firmware updates, consider replacing it.", "Mute smart speakers when you are having private conversations." } }
            };
        }

        public string GetRandomResponse(string topic)
        {
            string explanation = _explanations.TryGetValue(topic, out var exp) ? exp : "Here's some information on that topic.";
            string tip = _responses.TryGetValue(topic, out var list) ? list[_random.Next(list.Count)] : "Stay vigilant and stay safe online.";

            return $"{explanation}\n\n💡 Tip: {tip}";
        }
    }
}